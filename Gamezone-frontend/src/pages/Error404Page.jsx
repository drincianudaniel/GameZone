import { Typography } from "@mui/material";
import { Box, Container } from "@mui/system";
import Header from "../components/Header";

function Error404Page() {
  return (
    <>
      <Header></Header>
      <Container maxWidth="xl">
        <Box
          sx={{
            width: "100%",
            marginTop: 4,
            display: "flex",
            justifyContent: "center",
          }}
        >
          <Typography variant="h1">NOT FOUND</Typography>
        </Box>
      </Container>
    </>
  );
}

export default Error404Page;
