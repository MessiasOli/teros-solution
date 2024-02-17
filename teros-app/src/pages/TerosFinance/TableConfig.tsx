import { createColumnHelper } from "@tanstack/react-table";
import IOpenBanking from "../../model/Interface/IOpenBanking";
import ConfigurationIcon from "../../components/Icons/ConfigurationIcon";
import MostrarDetalhes from "./Modal/MostrarDetalhes";

const columnHelper = createColumnHelper<IOpenBanking>();
const headerStyle = 'text-center bg-white text-stone-950 px-2 z-index z-100'

export const columnsOpenBanking = [
  columnHelper.accessor("nomeFantazia", {
    header: () => <div className={headerStyle}>Nome Fantasia</div>,
    cell: (info) => <div>{info.getValue()}</div>,
    footer: (info) => info.column.id,
  }),
  columnHelper.accessor("descricao", {
    header: () => <div className={headerStyle}>Informações</div>,
    cell: (info) => <MostrarDetalhes msg={info.getValue()} nomeFantazia={info.cell.row.original.nomeFantazia} urlImg={info.cell.row.original.logo} />,
    footer: (info) => info.column.id,
  }),
  columnHelper.accessor("logo", {
    header: () => <div className={headerStyle}>Logo</div>,
    cell: (info) => <div className="bg-slate-50 flex justify-center rounded-md cursor-help" title={info.cell.row.original.nomeFantazia}><img className="p-1" src={info.getValue()} alt="Logo" style={{ width: '50 px', height: '50px' }}/></div>,
    footer: (info) => info.column.id,
  }),
  columnHelper.accessor("nomeEmpresa", {
    header: () => <div className={headerStyle}>Nome Empresarial</div>,
    cell: (info) => <div className="px-2">{info.getValue()}</div>,
    footer: (info) => info.column.id,
  }),
  columnHelper.accessor("urlConfiguration", {
    header: () => <div className={headerStyle}>Configuração</div>,
    cell: (info) => <div className="flex justify-center">
                      <span className="icon__bt" title="Informações de conexão e configuração">
                          <a href={info.getValue()}>{<ConfigurationIcon heigth={20} width={20} custonClass="cursor-pointer" />}</a>
                      </span>
                    </div>,
    footer: (info) => info.column.id,
  }),
];
