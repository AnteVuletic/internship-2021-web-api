import { useContext, useState, useEffect, useMemo } from "react";
import { UserContext } from "src/providers/UserProvider";
import { constructGet } from "src/utils/fetch";

export const useGet = (endpoint, headerOptions) => {
  const {
    state: { token },
  } = useContext(UserContext);

  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const options = useMemo(() => {
    let headers = {};
    if (headerOptions) {
      headers = { ...headerOptions };
    }
    if (token) {
      headers.Authorization = `Bearer ${token}`;
    }

    return headers;
  }, [headerOptions, token]);

  useEffect(() => {
    const request = constructGet(endpoint, options);
    const abortController = new AbortController();
    const signal = abortController.signal;

    const doRequest = async () => {
      setIsLoading(true);
      try {
        const response = await request();
        if (!signal.aborted) {
          setData(response);
        }
      } catch (e) {
        if (!signal.aborted) {
          setError(e?.message || "Oops something went wrong!");
        }
      } finally {
        if (!signal.aborted) {
          setIsLoading(false);
        }
      }
    };

    doRequest();

    return () => {
      abortController.abort();
    };
  }, [endpoint, options]);

  return { data, error, isLoading };
};
