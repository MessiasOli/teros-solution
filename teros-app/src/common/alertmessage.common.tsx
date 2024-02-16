import { toast, ToastOptions } from "react-toastify";

const options :ToastOptions = {
    position: 'top-right',
    autoClose: 3000
};

export const showMessage = (message: string | undefined) => toast.success(message, options);
export const showErrorMessage = (message: string | undefined) => toast.error(message, options);