import * as React from "react";
import Card from "@mui/material/Card";
import CardHeader from "@mui/material/CardHeader";
import CardMedia from "@mui/material/CardMedia";
import CardActions from "@mui/material/CardActions";
import IconButton from "@mui/material/IconButton";
import ClearIcon from "@mui/icons-material/Clear";
import { Link } from "react-router-dom";
import { useUser } from "../../hooks/useUser";
import GameService from "../../api/GameService";
import { useEffect } from "react";
import FavoriteButton from "../Buttons/FavoriteButton";
import { useConfirm } from "material-ui-confirm";

export default function GameCard(props) {
  const { user } = useUser();
  const confirm = useConfirm();

  useEffect(() => {}, []);

  const deleteGame = async () => {
    confirm({ description: "This will permanently delete the game." }).then(
      () => {
        GameService.deleteGame(props.data.id)
          .then((response) => {
            props.getGames();
          })
          .catch((err) => console.log(err));
      }
    );
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
        to={`/game/${props.data.id}/comments`}
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
      {user.IsLoggedIn && (
        <CardActions disableSpacing>
          <FavoriteButton
            id={props.data.id}
            isFavorite={props.data.isFavorite}
          />
          {user.IsAdmin && (
            <IconButton aria-label="Delete" onClick={deleteGame}>
              <ClearIcon></ClearIcon>
            </IconButton>
          )}
        </CardActions>
      )}
    </Card>
  );
}
