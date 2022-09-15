import { CircularProgress } from "@mui/material";
import { Box } from "@mui/system";

export default function SpinningLoading() {
  return (
    <Box
      sx={{
        width: "100%",
        display: "flex",
        justifyContent: "center",
        mt: 3,
        mb: 3,
      }}
    >
      <CircularProgress />
    </Box>
  );
}
