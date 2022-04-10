import { useContext, useCallback, useMemo, useState } from "react";
import { UserContext } from "src/providers/UserProvider";
import {
  constructDelete,
  constructGet,
  constructPost,
  constructPut,
} from "src/utils/fetch";

export const useFetch = (endpoint, method = "GET", headerOptions) => {
  const {
    state: { token },
  } = useContext(UserContext);
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(false);
  const [isSuccessful, setIsSuccessful] = useState(false);

  const options = useMemo(() => {
    let headers = {};
    if (headerOptions) {
      headers = { ...headerOptions };
    }

    if (token) {
      headers.Authorization = `Bearer ${token}`;
    }

    return headers;
  }, [token, headerOptions]);

  const requestFactoryDictionary = useMemo(
    () => ({
      GET: constructGet(endpoint, options),
      POST: constructPost(endpoint, options),
      DELETE: constructDelete(endpoint, options),
      PUT: constructPut(endpoint, options),
    }),
    [endpoint, options]
  );

  const handleRequest = useCallback(
    async (value) => {
      setIsLoading(true);
      try {
        const request = requestFactoryDictionary[method];
        const response = await request(value);
        setData(response);
        setIsSuccessful(true);
        setError(false);
      } catch (e) {
        setError(e?.message || "Ops something went wrong!");
        setIsSuccessful(false);
      } finally {
        setIsLoading(false);
      }
    },
    [method, requestFactoryDictionary]
  );

  return { handleRequest, data, error, isLoading, isSuccessful };
};
