import IComponentIcon from "../../Interface/IComponentIcon";

const ConfigurationIcon: React.FC<IComponentIcon> = ({
  heigth = 18,
  width = 18,
  color = "#eee",
  custonClass
}) => {
  return (
    <svg
      className={custonClass}
      fill={color}
      version="1.1"
      id="Capa_1"
      xmlns="http://www.w3.org/2000/svg"
      height={heigth}
      width={width}
      viewBox="0 0 124 124"
    >
      <g id="SVGRepo_bgCarrier" strokeWidth="0"></g>
      <g
        id="SVGRepo_tracerCarrier"
        strokeLinecap="round"
        strokeLinejoin="round"
      ></g>
      <g id="SVGRepo_iconCarrier">
        {" "}
        <g>
          {" "}
          <path d="M9.3,47H6c-3.3,0-6,2.9-6,6.2v18C0,74.6,2.7,77,6,77h3.4c5.4,0,8.7,7.9,4.8,11.8L12,91c-2.4,2.3-2.4,6.2,0,8.5l12.6,12.7 c2.3,2.3,6.1,2.3,8.5,0l3.7-3.7c3.8-3.8,10.2-1.1,10.2,4.3v5.4c0,3.3,2.7,5.8,6,5.8h18c3.3,0,6-2.4,6-5.8v-5.4 c0-5.3,6.5-8,10.2-4.2l3.7,3.7c2.3,2.3,6.1,2.3,8.5,0L112,99.7c2.4-2.4,2.3-6.2,0-8.5l-2.2-2.3C105.9,85.1,109.2,77.1,114.6,77.1 h3.4c3.3,0,6-2.399,6-5.8v-18c0-3.3-2.7-6.2-6-6.2h-3.3c-5.4,0-8.8-8.1-5-11.9l2.399-2.3c2.301-2.3,2.301-6.1,0-8.4L99.5,11.9 c-2.4-2.4-6.2-2.3-8.5,0L88.6,14C84.8,17.9,77,14.7,77,9.2v-3C77,2.9,74.3,0,71,0H53c-3.3,0-6,2.9-6,6.2v3c0,5.5-7.8,8.7-11.6,4.8 l-2.3-2.3c-2.3-2.4-6.2-2.4-8.5,0L11.9,24.4c-2.3,2.3-2.3,6.1,0,8.5l2.4,2.2C18.1,38.9,14.7,47,9.3,47z M62.2,38.2 c13.3,0,24,10.7,24,24c0,13.3-10.7,24-24,24c-13.3,0-24-10.7-24-24C38.2,48.9,49,38.2,62.2,38.2z"></path>{" "}
        </g>{" "}
      </g>
    </svg>
  );
};

export default ConfigurationIcon;
