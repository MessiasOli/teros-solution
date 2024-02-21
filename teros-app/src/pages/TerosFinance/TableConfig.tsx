import { createColumnHelper } from "@tanstack/react-table";
import ShowDetails from "./Modal/ShowDetails";
import ShowConfiguration from "./Modal/ShowConfiguration";
import { IOpenBanking } from "../../model/Interface/IOpenBanking";

const columnHelper = createColumnHelper<IOpenBanking>();
const headerStyle = 'text-center bg-white text-stone-950 px-2 z-index z-100'

export const columnsOpenBanking = [
  columnHelper.accessor("nomeFantasia", {
    header: () => <div className={headerStyle}>  Nome Fantasia</div>,
    cell: (info) => <div>{info.cell.row.original.favorito ? '⭐ ' : ''}{info.getValue()}</div>,
    footer: (info) => info.column.id,
  }),
  columnHelper.accessor("descricao", {
    header: () => <div className={headerStyle}>Informações</div>,
    cell: (info) => <ShowDetails msg={info.getValue()} nomeFantasia={info.cell.row.original.nomeFantasia} urlImg={info.cell.row.original.logo} />,
    footer: (info) => info.column.id,
  }),
  columnHelper.accessor("logo", {
    header: () => <div className={headerStyle}>Logo</div>,
    cell: (info) => <div className="bg-slate-50 flex justify-center rounded-md cursor-help" title={info.cell.row.original.nomeFantasia}><img className="p-1" src={info.getValue()} alt="Logo" style={{ width: '50 px', height: '50px' }}/></div>,
    footer: (info) => info.column.id,
  }),
  columnHelper.accessor("nomeEmpresa", {
    header: () => <div className={headerStyle}>Nome Empresarial</div>,
    cell: (info) => <div className="px-2">{info.getValue()}</div>,
    footer: (info) => info.column.id,
  }),
  columnHelper.accessor("authorisationServersList", {
    header: () => <div className={headerStyle}>Configuração</div>,
    cell: (info) => <ShowConfiguration openBanking={info.cell.row.original} />,
    footer: (info) => info.column.id,
  }),
];
