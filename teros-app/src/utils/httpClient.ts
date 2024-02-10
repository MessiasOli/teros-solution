import axios from "axios";
const env = import.meta.env;

const httpClient = axios.create({
  baseURL: env.VITE_BACKEND_ADDR,
  headers: {
    "Content-Type": "application/json; charset=UTF-8",
  },
});


export default httpClient;
