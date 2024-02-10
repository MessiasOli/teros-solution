export interface NavItemProps {
  id: number;
  label: string;
  href: string;
  icon: string;
}

export const MenuList: NavItemProps[] = [
    { id: 1, label: "Início", href: "/home", icon: "home" },
    { id: 2, label: "Automação", href: "/terosFinance", icon: "auto" },
    { id: 3, label: "Configuração", href: "/configuration", icon: "config" },
    { id: 4, label: "Sobre", href: "/about", icon: "info" },
];
