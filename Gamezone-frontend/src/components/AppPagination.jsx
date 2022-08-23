import { Box, Pagination } from "@mui/material";

function AppPagination() {

  return (
    <Box
      justifyContent={"center"}
      allignItems="center"
      display={"flex"}
      sx={{ paddingBottom: "20px" }}
    >
      <Pagination
        count={10}
        variant="outlined"
        color="primary"
      />
    </Box>
  );
}

export default AppPagination;
