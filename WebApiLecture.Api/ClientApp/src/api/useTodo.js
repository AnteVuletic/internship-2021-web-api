import { useFetch } from "src/hooks/useFetch";
import { useGet } from "src/hooks/useGet";

export const useGetTodos = () => useGet("api/Todo");

export const useAddTodo = () => useFetch("api/Todo/", "POST");
