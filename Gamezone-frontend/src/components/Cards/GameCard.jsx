import * as React from "react";
import Card from "@mui/material/Card";
import CardHeader from "@mui/material/CardHeader";
import CardMedia from "@mui/material/CardMedia";
import CardActions from "@mui/material/CardActions";
import IconButton from "@mui/material/IconButton";
import FavoriteIcon from "@mui/icons-material/Favorite";
import ClearIcon from "@mui/icons-material/Clear";
import axios from "axios";
import { Link } from "react-router-dom";

export default function GameCard(props) {
  const deleteGame = async () => {
    await axios
      .delete(`${process.env.REACT_APP_SERVERIP}/Games/${props.data.id}`)
      .then((response) => {
        const updatedGames = props.games.filter(item => item.id !== props.data.id)
        props.setGames(updatedGames);
      })
      .catch((err) => console.log(err));
  };

  return (
    <Card
      sx={{
        maxWidth: 300,
        "&:hover": { boxShadow: "-1px 10px 29px 0px rgba(0, 0, 0, 0.8)" },
      }}
    >
      <Link
        style={{ textDecoration: "none", color: "black" }}
        to={`/game/${props.data.id}`}
      >
        <CardHeader
          sx={{
            display: "flex",
            overflow: "hidden",
            "& .MuiCardHeader-content": {
              overflow: "hidden",
            },
          }}
          titleTypographyProps={{ noWrap: true }}
          title={props.data.name}
        />
        <CardMedia
          sx={{ width: 300 }}
          component="img"
          height="350"
          image={props.data.imageSrc}
        />
      </Link>
      <CardActions disableSpacing>
        <IconButton aria-label="add to favorites">
          <FavoriteIcon />
        </IconButton>
        <IconButton aria-label="Delete" onClick={deleteGame}>
          <ClearIcon></ClearIcon>
        </IconButton>
      </CardActions>
    </Card>
  );
}
