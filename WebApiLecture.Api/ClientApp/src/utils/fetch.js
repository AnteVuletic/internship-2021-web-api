const defaultHeader = {
  Accept: "application/json",
  "Content-Type": "application/json",
};

export const constructGet =
  (endpoint, headerOptions = {}) =>
  () =>
    fetch(endpoint, {
      method: "GET",
      headers: {
        ...defaultHeader,
        ...headerOptions,
      },
    });

export const constructPost =
  (endpoint, headerOptions = {}) =>
  (body) =>
    fetch(endpoint, {
      method: "POST",
      body: JSON.stringify(body),
      headers: {
        ...defaultHeader,
        ...headerOptions,
      },
    });

export const constructPut =
  (endpoint, headerOptions = {}) =>
  (body) =>
    fetch(endpoint, {
      method: "PUT",
      body: JSON.stringify(body),
      headers: {
        ...defaultHeader,
        ...headerOptions,
      },
    });

export const constructDelete =
  (endpoint, headerOptions = {}) =>
  () =>
    fetch(endpoint, {
      method: "DELETE",
      headers: {
        ...defaultHeader,
        ...headerOptions,
      },
    });
