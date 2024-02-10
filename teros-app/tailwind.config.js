const plugin = require('tailwindcss/plugin')

module.exports = {
  content: ["./index.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
  theme: {
    extend: {
      maxHeight: {
        '128': '128vh'
      },
      colors: {
        transparent: 'transparent',
        cproject: {
          light: "##EEE5E9",
          semilight: "#92dce5",
          DEFAULT: "##7C7C7C",
          semidark: "##D64933",
          dark: "#000000",
        },
        corange: {
          DEFAULT: "#FF9100"
        },
        line: {
          pink: "#de35e3"
        },
        cgray: {
          head: "#CCCCCC",
          linesA: "#F0F0F0",
          linesB: "#EBEBEB",
        },
      },
      screens: {
        '3xl': '1600px',
      },
      fontSize: {
        'xxs': '.60rem',
      }
    },
  },
  plugins: [
  ],
};
