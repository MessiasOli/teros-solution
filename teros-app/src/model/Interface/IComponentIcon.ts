export default interface IComponentIcon {
  width: number;
  heigth: number;
  color?: string | undefined;
  custonClass?: string | undefined;
  title?: string | undefined;
  onClick?: React.MouseEventHandler<HTMLDivElement>;
}
