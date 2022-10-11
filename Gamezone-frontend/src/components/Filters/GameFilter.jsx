import {
  Box,
  Button,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select,
} from "@mui/material";
import { useState } from "react";
import { useEffect } from "react";
import DeveloperService from "../../api/DeveloperService";
import GenreService from "../../api/GenreService";
import PlatformService from "../../api/PlatformService";
import { useUser } from "../../hooks/useUser";

function GameFilter(props) {
  const [genres, setGenres] = useState([]);
  const [developers, setDevelopers] = useState([]);
  const [platforms, setPlatforms] = useState([]);
  const { user, loadingUser } = useUser();

  useEffect(() => {
    GenreService.getGenres().then((res) => {
      setGenres(res.data);
    });

    DeveloperService.getDevelopers().then((res) => {
      setDevelopers(res.data);
    });

    PlatformService.getPlatforms().then((res) => {
      setPlatforms(res.data);
    });
  }, []);

  const handleClick = () => {
    if (user.IsLoggedIn) {
      props.getGames();
    }

    if (!user.IsLoggedIn) {
      props.getGamesWhenLoggedOut();
    }
  };

  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        width: "100%",
        backgroundColor: "white",
      }}
    >
      <Grid
        container
        spacing={4}
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          width: "100%",
        }}
      >
        <Grid item xs={12} md={3}>
          <FormControl fullWidth sx={{ m: 1 }}>
            <InputLabel id="demo-simple-select-autowidth-label">
              Genre
            </InputLabel>
            <Select
              labelId="demo-simple-select-autowidth-label"
              id="demo-simple-select-autowidth"
              value={props.genre}
              onChange={props.handleChangeGenre}
              label="Genre"
            >
              <MenuItem value="">Empty</MenuItem>
              {genres.map((genre) => {
                return (
                  <MenuItem key={genre.id} value={genre.name}>
                    {genre.name}
                  </MenuItem>
                );
              })}
            </Select>
          </FormControl>
        </Grid>

        <Grid item md={3} xs={12} sx={{ width: "100%" }}>
          <FormControl fullWidth sx={{ m: 1 }}>
            <InputLabel id="demo-simple-select-autowidth-label">
              Developer
            </InputLabel>
            <Select
              labelId="demo-simple-select-autowidth-label"
              id="demo-simple-select-autowidth"
              value={props.developer}
              onChange={props.handleChangeDeveloper}
              label="Developer"
            >
              <MenuItem value="">Empty</MenuItem>
              {developers.map((developer) => {
                return (
                  <MenuItem key={developer.id} value={developer.name}>
                    {developer.name}
                  </MenuItem>
                );
              })}
            </Select>
          </FormControl>
        </Grid>

        <Grid item xs={12} md={3}>
          <FormControl fullWidth sx={{ m: 1 }}>
            <InputLabel id="demo-simple-select-autowidth-label">
              Platform
            </InputLabel>
            <Select
              labelId="demo-simple-select-autowidth-label"
              id="demo-simple-select-autowidth"
              value={props.platform}
              onChange={props.handleChangePlatform}
              label="Platform"
            >
              <MenuItem value="">Empty</MenuItem>
              {platforms.map((platform) => {
                return (
                  <MenuItem key={platform.id} value={platform.name}>
                    {platform.name}
                  </MenuItem>
                );
              })}
            </Select>
          </FormControl>
        </Grid>

        <Grid item xs={12} md={3}>
          <Button onClick={handleClick} sx={{ width: "100%" }}>
            Apply filter
          </Button>
        </Grid>
      </Grid>
    </Box>
  );
}
export default GameFilter;
