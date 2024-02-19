import { useState } from "react";
import { useQuery } from "react-query";
import DefaultResponse from "../../model/DefaultResponse";
import Carregando from "../../components/Carregando";
import ErroCarregar from "../../components/ErroCarregar";
import {
  flexRender,
  getCoreRowModel,
  useReactTable,
} from "@tanstack/react-table";
import { columnsOpenBanking } from "./TableConfig";
import React from "react";
import { DebouncedInput } from "./DebounceInput";
import { IOpenBanking } from "../../model/Interface/IOpenBanking";

function TerosFinance() {
  const [globalFilter, setGlobalFilter] = React.useState("");
  const [openBankingList, setOpenBankingList] = useState<IOpenBanking[]>([]);
  const [openBankingFiltered, setOpenBankingFiltered] = useState<
    IOpenBanking[]
  >([]);

  const table = useReactTable({
    data: openBankingFiltered,
    columns: columnsOpenBanking,
    getCoreRowModel: getCoreRowModel(),
  });

  const queryLoading = useQuery<DefaultResponse<IOpenBanking[]>>(
    ["GetAllOpenBanking"],
    {
      onSuccess: (resp) => {
        setOpenBankingList(resp.data);
        setOpenBankingFiltered(resp.data);
        applyFilter();
      },
    }
  );

  function applyFilter() {
    if (globalFilter.length > 0) {
      let filtered = openBankingList.filter(
        (o) =>
          o.nomeEmpresa.toUpperCase().includes(globalFilter.toUpperCase()) ||
          o.nomeFantasia.toUpperCase().includes(globalFilter.toUpperCase())
      );
      setOpenBankingFiltered(filtered);
    } else setOpenBankingFiltered(openBankingList);
  }

  React.useEffect(() => {
    applyFilter()
  }, [globalFilter]);

  if (queryLoading.isLoading) return <Carregando />;
  if (queryLoading.isError) return <ErroCarregar />;

  return (
    <div>
      <p className="text-3xl font-bold mb-2">Tabela Open Banking</p>
      <div>
        <div className="flex justify-between">
          <DebouncedInput
            value={globalFilter ?? ""}
            onChange={(value) => setGlobalFilter(String(value))}
            className="p-1 mb-2 text-lg shadow border border-block"
            placeholder="Pesquise rápido aqui..."
          />
          <div className="self-end mr-2">
            <p>Número de linhas: {openBankingFiltered.length}</p>
          </div>
        </div>
        <div className="table__openfinance h-[68vh] overflow-y-auto mt-4 teros__anitmation">
          <table { ...{style: { width: "100%"}} }>
            <thead className="sticky top-0">
              {table.getHeaderGroups().map((headerGroup) => (
                <tr key={headerGroup.id}>
                  {headerGroup.headers.map((header) => (
                    <th key={header.id}>
                      {header.isPlaceholder
                        ? null
                        : flexRender(
                            header.column.columnDef.header,
                            header.getContext()
                          )}
                    </th>
                  ))}
                </tr>
              ))}
            </thead>
            <tbody>
              {table.getRowModel().rows.map((row) => (
                <tr key={row.id}>
                  {row.getVisibleCells().map((cell) => (
                    <td key={cell.id}>
                      {flexRender(
                        cell.column.columnDef.cell,
                        cell.getContext()
                      )}
                    </td>
                  ))}
                </tr>
              ))}
            </tbody>
          </table>
          {!openBankingFiltered.length && globalFilter.length > 0 ? <p>A palavra <strong>{globalFilter}</strong> não foi encontrada em nossos registros. 😊</p> : null }
        </div>
      </div>
    </div>
  );
}

export default TerosFinance;