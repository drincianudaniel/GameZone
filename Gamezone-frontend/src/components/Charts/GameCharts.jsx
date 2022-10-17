import { Box, Container, Typography, Divider, Grid } from "@mui/material";
import { useEffect } from "react";
import { useState } from "react";
import GameService from "../../api/GameService";
import CanvasJSReact from "../../assets/canvasjs.react";

var CanvasJS = CanvasJSReact.CanvasJS;
var CanvasJSChart = CanvasJSReact.CanvasJSChart;

export default function GameCharts() {
  const [genreAverage, setGenreAverage] = useState([]);
  const [genreCount, setGenreCount] = useState([]);
  const [platformCount, setPlatformCount] = useState([]);

  useEffect(() => {
    GameService.GetGamesChart().then((res) => {
      setGenreAverage(res.data.genreAverage);
      setGenreCount(res.data.genreCount);
      setPlatformCount(res.data.platformCount);
    });
  }, []);
  const genresCount = {
    animationEnabled: true,
    exportEnabled: true,
    theme: "light2", // "light1", "dark1", "dark2"
    title: {
      text: "Games count by genre",
    },
    data: [
      {
        type: "pie",
        indexLabel: "{label}: {y}",
        startAngle: -90,
        dataPoints: genreCount.map((el) => {
          return {
            y: el.count,
            label: el.name,
          };
        }),
      },
    ],
  };

  const platformsCount = {
    animationEnabled: true,
    exportEnabled: true,
    theme: "light2", // "light1", "dark1", "dark2"
    title: {
      text: "Games count by platform",
    },
    data: [
      {
        type: "pie",
        indexLabel: "{label}: {y}",
        startAngle: -90,
        dataPoints: platformCount.map((el) => {
          return {
            y: el.count,
            label: el.name,
          };
        }),
      },
    ],
  };

  const genresAverage = {
    animationEnabled: true,
    theme: "light2",
    title: {
      text: "Genres by average rating",
    },
    axisY: {
      maximum: 10.5,
    },
    data: [
      {
        type: "line",
        indexLabelFontSize: 16,
        dataPoints: genreAverage.map((el) => {
          return {
            y: el.averageRating,
            label: el.name,
          };
        }),
      },
    ],
  };

  return (
    <Container maxWidth="lg">
      <Box
        sx={{
  
        }}
      >
        <Grid Container>
          <Grid item lg={6}>
            <CanvasJSChart options={genresCount} />
          </Grid>
          <Grid item lg={6}>
            <CanvasJSChart options={platformsCount} />
          </Grid>
        </Grid>
        <Divider></Divider>
        <CanvasJSChart options={genresAverage} />
      </Box>
    </Container>
  );
}
