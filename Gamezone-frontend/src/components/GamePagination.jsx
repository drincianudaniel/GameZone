import { useEffect, useState } from "react";
import Pagination from "@mui/material/Pagination";

const pageSize = 3;
function GamePagination({getData}) {
  const [pagination, setPagination] = useState({
    count: 0,
    from: 0,
    to: pageSize,
  });

  useEffect(() => {
      getData({ from: pagination.from, to: pagination.to })
      .then((response) => {
        setPagination({...pagination, count: response.count});
        console.log(response);
      });
  }, []);

  return (
    <div>
      {console.log(pagination)}
      <Pagination
        count={Math.ceil(pagination.count / pageSize)}
        shape="rounded"
      />
    </div>
  );
}

export default GamePagination;
