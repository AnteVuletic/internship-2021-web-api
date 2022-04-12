import { useFetch } from "src/hooks/useFetch";
import { useGet } from "src/hooks/useGet";

export const useGetTodos = () => useGet("api/Todo");

export const useAddTodo = () => useFetch("api/Todo/", "POST");

export const useGetTodoDetail = (id) => useGet(`api/Todo/${id}`);

export const usePutTodo = (id) => useFetch(`api/Todo/${id}`, "PUT");

export const useDeleteTodo = () => useFetch('api/Todo', "DELETE");
