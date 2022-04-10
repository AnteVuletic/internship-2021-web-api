import {
  constructDelete,
  constructGet,
  constructPost,
  constructPut,
} from "src/utils/fetch";

export const useFetch = (endpoint, headerOptions = {}) => {
  return {
    get: constructGet(endpoint, headerOptions),
    post: constructPost(endpoint, headerOptions),
    delete: constructDelete(endpoint, headerOptions),
    put: constructPut(endpoint, headerOptions),
  };
};
