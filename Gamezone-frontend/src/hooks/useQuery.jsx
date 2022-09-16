import { useState } from "react";

const useQuery = (url, method = "GET") => {
  const [data, setData] = useState();
  const [error, setError] = useState();
  const [isLoading, setLoading] = useState(true);
  console.log(`sending ${method} request to ${url}`);

  fetch(`${process.env.REACT_APP_SERVERIP}/${url}`, {
    method: method,
  })
    .then((res) => res.json())
    .then((data) => {
      setData(data.data);
      console.log(data.data)
    })
    .catch((x) => setError("error"))
    .finally(() => setLoading(false));
  return { data: data, isLoading: isLoading, error: error };
};

export default useQuery;
