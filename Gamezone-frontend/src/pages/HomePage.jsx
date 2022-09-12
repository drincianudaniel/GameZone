import Header from "../components/Header";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import { Typography } from "@mui/material";
import SimpleSlider from "../components/Carousels/LatestGames";

function HomePage() {
  return (
    <div>
      <Header />
      
      <Container maxWidth="m">
        <Box sx={{ bgcolor: "#cfe8fc", height: "100%" }}>
        <SimpleSlider/>
        </Box>
      </Container>
    </div>
  );
}

export default HomePage;
