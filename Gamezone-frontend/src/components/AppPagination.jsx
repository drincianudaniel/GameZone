import { Box, Pagination } from "@mui/material";


function AppPagination(props) {

  const handleChange = (page) =>{
    props.setPage(page)
  }

  return (
    <Box
      justifyContent={"center"}
      display={"flex"}
      sx={{ paddingBottom: "20px" }}
    >
      <Pagination onChange={(e) =>handleChange(e.target.textContent)} count={props.numberOfPages} variant="outlined" color="primary" />
    </Box>
  );
}

export default AppPagination;
