import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import { QueryClient, QueryClientProvider, QueryKey } from "react-query";
import httpClient from "./utils/httpClient";
import AppRoutes from "./Routes.tsx";
import { ToastContainer } from "react-toastify";
import { setLocale } from "yup";
import { ptForm } from "yup-locale-pt";
import 'react-toastify/dist/ReactToastify.css';
import "./index.css"

setLocale({
  ...ptForm,
  mixed: {
    ...ptForm.mixed,
    notType: (params) =>
      `O valor informado ${
        params.originalValue ? "(" + params.originalValue + ")" : ""
      } não está de acordo com o tipo esperado (${params.type}).`,
    required: "Este campo é obrigatório.",
  },
});

const defaultQueryFn = async ({ queryKey }: { queryKey: QueryKey }) => {
  const queryOpts = (queryKey as any[]).reduce<{
    url: unknown[];
    params: unknown[];
  }>(
    (prev, curr) => {
      switch (typeof curr) {
        case "undefined":
          break;
        case "object":
          prev.params.push(new URLSearchParams(curr as any).toString());
          break;
        default:
          prev.url.push(curr);
          break;
      }
      return prev;
    },
    { url: [], params: [] }
  );

  let url = queryOpts.url.join("/");
  url += queryOpts.params.length > 0 ? `?${queryOpts.params.join("&")}` : "";

  const response = await httpClient.get(url);
  return response.data;
};

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      queryFn: defaultQueryFn,
      refetchOnWindowFocus: false,
    },
  },
});

const env = import.meta.env;
console.log("the app is running in: ", env.MODE);

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <ToastContainer limit={5} />
      <QueryClientProvider client={queryClient}>
        <BrowserRouter>
          <AppRoutes />
        </BrowserRouter>
      </QueryClientProvider>
  </React.StrictMode>
);
