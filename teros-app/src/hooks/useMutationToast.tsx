import { toast } from "react-toastify";
import { MutationMethod } from "../model/enums/MutationMethod";
import httpClient from "../utils/httpClient";
import { useMutation, useQueryClient } from "react-query";
import { AxiosError } from "axios";

export function useDeleteMutationToast<TVariables>({
  route,
  invalidateQueryKey,
  stateMessages,
}: {
  route: string;
  invalidateQueryKey: string | string[];
  stateMessages?: {
    pending: string;
    success: string;
    error: string;
  };
}) {
  return useMutationToast<TVariables>(route, invalidateQueryKey, MutationMethod.DELETE, stateMessages);
}

export function usePostMutationToast<TVariables>({
  route,
  invalidateQueryKey,
  stateMessages,
  onSuccessCb,
  onErrorCb,
}: {
  route: string;
  invalidateQueryKey: string | string[];
  stateMessages?: {
    pending: string;
    success: string;
    error: string;
  };
  onSuccessCb?: ((data: any, variables: TVariables, context: unknown) => void | Promise<unknown>) | undefined;
  onErrorCb?: ((data: any, variables: TVariables, context: unknown) => void | Promise<unknown>) | undefined;
}) {
  return useMutationToast<TVariables>(route, invalidateQueryKey, MutationMethod.POST, stateMessages, onSuccessCb, onErrorCb);
}

export function usePutMutationToast<TVariables>({
  route,
  invalidateQueryKey,
  stateMessages,
}: {
  route: string;
  invalidateQueryKey: string | string[] | any;
  stateMessages?: {
    pending: string;
    success: string;
    error: string;
  };
}) {
  return useMutationToast<TVariables>(route, invalidateQueryKey, MutationMethod.PUT, stateMessages);
}

export default function useMutationToast<TVariables>(
  route: string,
  invalidateQueryKey: string | string[],
  mutationMethod: MutationMethod = MutationMethod.POST,
  stateMessages: {
    pending: string;
    success: string;
    error: string;
  } = {
    pending: "Calculando...",
    success: "Calculado!",
    error: "Falha ao calcular!",
  },
  onSuccessCb?: ((data: any, variables: TVariables, context: unknown) => void | Promise<unknown>) | undefined,
  onErrorCb?: ((data: any, variables: TVariables, context: unknown) => void | Promise<unknown>) | undefined
) {
  const queryClient = useQueryClient();

  const mutation = useMutation<any, any, TVariables>(
    data => {
      return mutationMethod === MutationMethod.POST
        ? httpClient.post(route, data)
        : mutationMethod === MutationMethod.PUT
          ? httpClient.put(route, data)
          : httpClient.delete(`${route}/${data}`);
    },
    { onSuccess: onSuccessCb, onError: onErrorCb }
  );

  async function calculateAndSave(data: TVariables) {
    await toast.promise(mutation.mutateAsync(data), {
      ...stateMessages,
      error: {
        render({ data }) {
          return responseError(data, stateMessages.error);
        },
      },
    });

    typeof invalidateQueryKey === "string"
      ? queryClient.invalidateQueries(invalidateQueryKey)
      : invalidateQueryKey.forEach(query => queryClient.invalidateQueries(query));
  }

  return calculateAndSave;
}

export function useMutationState<TVariables>({
  route,
  invalidateQueryKey,
  stateMessages,
  onSuccessCb,
  onErrorCb,
}: {
  route: string;
  invalidateQueryKey: string | string[];
  stateMessages: {
    pending: string;
    success: string;
    error: string;
  };
  onSuccessCb?: ((data: any, variables: TVariables, context: unknown) => void | Promise<unknown>) | undefined;
  onErrorCb?: ((data: any, variables: TVariables, context: unknown) => void | Promise<unknown>) | undefined;
}) {
  const queryClient = useQueryClient();

  const mutation = useMutation<any, any, TVariables>(data => httpClient.post(route, data), { onSuccess: onSuccessCb, onError: onErrorCb });

  const { isError, isLoading, isSuccess } = mutation;

  async function calculateAndSave(data: TVariables) {
    await toast.promise(mutation.mutateAsync(data), {
      ...stateMessages,
      error: {
        render({ data }) {
          return responseError(data, stateMessages.error);
        },
      },
    });

    typeof invalidateQueryKey === "string"
      ? queryClient.invalidateQueries(invalidateQueryKey)
      : invalidateQueryKey.forEach(query => queryClient.invalidateQueries(query));
  }

  return { isError, isLoading, isSuccess, mutateAsync: calculateAndSave };
}

const responseError = (data: unknown, defaultMessage: string) => {
  let message = "";
  if (data instanceof AxiosError) {
    if (data?.response?.data.message) message = data?.response?.data.message;
    else if (data?.response?.data.title) message = data?.response?.data.title;
    else message = defaultMessage;
  } else message = defaultMessage;

  return message;
};
