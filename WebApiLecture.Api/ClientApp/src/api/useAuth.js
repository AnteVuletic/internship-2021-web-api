import { useFetch } from "src/hooks/useFetch";

export const useLogin = () => {
  const { post } = useFetch("/api/Auth/login");

  return { login: post };
};

export const useRegister = () => {
  const { post } = useFetch("/api/Auth/register");

  return { register: post };
};
