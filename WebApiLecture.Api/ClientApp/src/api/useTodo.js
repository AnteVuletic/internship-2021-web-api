import { useState, useEffect, useCallback } from "react";

import { useFetch } from "src/hooks/useFetch";

export const useGetTodos = () => {
  const { get } = useFetch("api/Todo");
  const [data, setData] = useState([]);
  const [error, setError] = useState(null);

  const handleGet = useCallback(async () => {
    try {
      const todos = await get();
      setData(todos);
    } catch (e) {
      setError(e.message);
    }
  }, [get]);

  useEffect(() => {
    handleGet();
  }, [handleGet]);

  return { data, error };
};
