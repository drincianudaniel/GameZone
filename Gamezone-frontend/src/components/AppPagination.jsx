import { Box, Pagination } from "@mui/material";
import { useState } from "react";


function AppPagination(props) {

  const [pagination, setPagination] = useState({
    from: 0,
    to: props.pageSize
})
  const handleChange = (event, value) => {
    props.setPage(value);
  };

  return (
    <Box
      justifyContent={"center"}
      display={"flex"}
      sx={{ paddingBottom: "20px" }}
    >
      <Pagination  count={props.numberOfPages} onChange={handleChange} variant="outlined" color="primary" />
    </Box>
  );
}

export default AppPagination;
