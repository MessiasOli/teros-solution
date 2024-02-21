export default interface DefaultResponse<T> {
    data: T;
    isError: boolean;
    message: string;
}