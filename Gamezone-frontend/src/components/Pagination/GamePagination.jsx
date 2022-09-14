import Pagination from "@mui/material/Pagination";

function GamePagination(props) {
  const handleChange = (event, value) => {
    props.setPage(value);
  };

  return (
    <div>
      <Pagination
        onChange={handleChange}
        count={props.numberOfPages}
        shape="rounded"
      />
    </div>
  );
}

export default GamePagination;
