import React from "react";
import { useGetTodos } from "src/api/useTodo";

import List from "src/components/List";

const Todo = () => {
  const columns = ["Title", "Description"];
  const { data, error } = useGetTodos();

  const rows = data.map((data) => [
    <span>{data.title}</span>,
    <span>{data.description}</span>,
  ]);

  return (
    <div>
      <List columns={columns} rows={rows} error={error} />;
    </div>
  );
};

export default Todo;
