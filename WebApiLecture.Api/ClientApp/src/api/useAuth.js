import { useFetch } from "src/hooks/useFetch";

export const useLogin = () => (useFetch("/api/Auth/login", 'POST'));

export const useRegister = () => (useFetch("/api/Auth/register", 'POST'));
