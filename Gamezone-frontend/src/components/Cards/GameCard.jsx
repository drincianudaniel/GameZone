import * as React from "react";
import Card from "@mui/material/Card";
import CardHeader from "@mui/material/CardHeader";
import CardMedia from "@mui/material/CardMedia";
import CardActions from "@mui/material/CardActions";
import IconButton from "@mui/material/IconButton";
import FavoriteIcon from "@mui/icons-material/Favorite";
import ClearIcon from "@mui/icons-material/Clear";
import { Link } from "react-router-dom";
import { useUser } from "../../hooks/useUser";
import GameService from "../../api/GameService";
import UserService from "../../api/UserService";
import { toast } from "react-toastify";
import { useEffect } from "react";
import { useState } from "react";
import LoadingBarComponent from "../LoadingComponents/LoadingBar";

export default function GameCard(props) {
  const { user } = useUser();
  const [isFav, setIsFav] = React.useState(false);
  const [progress, setProgress] = useState(0);

  useEffect(() => {
    isFavCheck()
  }, []);

  const deleteGame = async () => {
    GameService.deleteGame(props.data.id)
      .then((response) => {
        props.getGames();
      })
      .catch((err) => console.log(err));
  };

  const addGameToFavorite = async () => {
    setProgress(50);
    UserService.AddGameToFavorite(user.Id, props.data.id).then((res) => {
      setProgress(100);
      toast.success("Game added to favorite");
      setIsFav(true);
    });
  };

  const removeFromFavorite = async () => {
    setProgress(50);
    UserService.RemoveGameFromFavorite(user.Id, props.data.id).then((res) => {
      toast.success("Game removed from favorite");
      setProgress(100);
      setIsFav(false);
    });
  };

  const isFavCheck = () => {
    setIsFav(props.data.isFavorite);
  };
  return (
    <Card
      sx={{
        maxWidth: 300,
        "&:hover": { boxShadow: "-1px 10px 29px 0px rgba(0, 0, 0, 0.8)" },
      }}
    >
      <LoadingBarComponent progress={progress} setProgress={setProgress} />
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
          {user.IsLoggedIn && (
            <>
              {isFav ? (
                <IconButton
                  aria-label="remove game from favorites"
                  onClick={removeFromFavorite}
                >
                  <FavoriteIcon sx={{ color: "red" }} />
                </IconButton>
              ) : (
                <IconButton
                  aria-label="add to favorites"
                  onClick={addGameToFavorite}
                >
                  <FavoriteIcon />
                </IconButton>
              )}
            </>
          )}

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
