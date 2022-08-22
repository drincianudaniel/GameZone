import { Box, Pagination } from "@mui/material";
import { makeStyles } from "@mui/styles";

function AppPagination() {
  const useStyles = makeStyles(() => ({
    ul: {
      "& .MuiPaginationItem-root": {
        color: "white",
        "&.Mui-selected": {
          color: "white",
          // borderRadius: '50%',
        },
      },
    },
  }));

  const classes = useStyles();

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
        classes={{
          root: classes.ul,
        }}
      />
    </Box>
  );
}

export default AppPagination;
