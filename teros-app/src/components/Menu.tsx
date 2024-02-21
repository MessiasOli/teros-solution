import { Link } from "react-router-dom";
import React from "react";
import HomeIcon from "./Icons/HomeIcon";
import ConfigurationIcon from "./Icons/ConfigurationIcon";
import AutomationIcon from "./Icons/AutomationIcon";
import InfoIcon from "./Icons/InfoIcon";
import "./Menu.css"
import { SetPageSelected } from "../utils/handlers";
import { MenuList, NavItemProps } from "./NavItems";

const Item: React.FC<NavItemProps> = ({ id, label, icon }) => {
  const icons: any = new Map<string, any>([
    ['home', <HomeIcon color={"#eee"} heigth={20} width={20} /> ],
    ['auto', <AutomationIcon color={"#eee"} heigth={20} width={20} /> ],
    ['config', <ConfigurationIcon color={"#eee"} heigth={20} width={20} /> ],
    ['info', <InfoIcon color={"#eee"} heigth={20} width={20} /> ]
  ])

  return(
      <div className="flex items-center cursor-pointer my-0.5" >
        {icons.get(icon)}
        <label 
          id={"item-"+id} 
          className="label-title text-ms selectable ml-3 pb-0 cursor-pointer"
          >
            {label}
        </label>
      </div>
  )
};

function Menu() {
  return (
    <div className="bg-gray-800 max-h text-white py-2">
      <div className="container flex flex-col mx-auto justify-start items-left">
        {MenuList.map((m, i) => (
          <Link
            to={m.href}
            className="text-white mx-3"
            key={`menu-${i}`}
            onClick={() => SetPageSelected(`item-${i+1}`)}
          >
            <Item {...m} />
          </Link>
        ))}
      </div>
    </div>
  );
}

export default Menu;
