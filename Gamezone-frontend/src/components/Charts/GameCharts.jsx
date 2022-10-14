import { Typography } from "@mui/material";
import { useEffect } from "react";
import { useState } from "react";
import GameService from "../../api/GameService";
import CanvasJSReact from "../../assets/canvasjs.react";
var CanvasJS = CanvasJSReact.CanvasJS;
var CanvasJSChart = CanvasJSReact.CanvasJSChart;

export default function GameCharts() {
  const [data, setData] = useState([]);

  useEffect(() => {
    GameService.GetGamesChart().then((res) => {
      setData(res.data.genreData);
      console.log(data);
    });
  }, []);
  const options = {
    animationEnabled: true,
    exportEnabled: true,
    theme: "light2", // "light1", "dark1", "dark2"
    title: {
      text: "Genres",
    },
    data: [
      {
        type: "pie",
        indexLabel: "{label}: {y}%",
        startAngle: -90,
        dataPoints: data.map((el) => {
          return {
            y: el.count,
            label: el.name,
          };
        }),
      },
    ],
  };
  return (
    <>
      <Typography>Here are some game charts</Typography>
      <CanvasJSChart
        options={options}
        /* onRef={ref => this.chart = ref} */
      />
    </>
  );
}
