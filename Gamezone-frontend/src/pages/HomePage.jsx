import Header from "../components/Header";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import { Grid, Typography } from "@mui/material";
import SimpleSlider from "../components/Carousels/LatestGames";
import Divider from '@mui/material/Divider';

function HomePage() {
  return (
    <div>
      <Header />
      <Container maxWidth="xl">
        <Box sx={{ height: "100%", marginTop: 2 }}>
        
          <Grid container spacing={2}>
            <Grid item xs={8}>
            <Typography>Latest games added</Typography>
            <Divider></Divider>
            <SimpleSlider/>
            </Grid>
            <Grid item xs={4}>
              Top Action Games
            </Grid>
          </Grid>

        </Box>
      </Container>
    </div>
  );
}

export default HomePage;
