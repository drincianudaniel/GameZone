import { useEffect } from "react";
import { useState } from "react";
import { toast } from "react-toastify";
import UserService from "../../api/UserService";
import { useUser } from "../../hooks/useUser";
import LoadingBarComponent from "../LoadingComponents/LoadingBar";
import FavoriteIcon from "@mui/icons-material/Favorite";
import { IconButton } from "@mui/material";

export default function FavoriteButton(props) {
  const [isFav, setIsFav] = useState(false);
  const { user } = useUser();

  useEffect(() => {
    isFavCheck();
  }, []);
  
  const isFavCheck = () => {
    setIsFav(props.isFavorite);
  };

  const [progress, setProgress] = useState(0);

  const addGameToFavorite = async () => {
    setProgress(50);
    UserService.AddGameToFavorite(user.Id, props.id).then((res) => {
      setProgress(100);
      toast.success("Game added to favorite");
      setIsFav(true);
    });
  };

  const removeFromFavorite = async () => {
    setProgress(50);
    UserService.RemoveGameFromFavorite(user.Id, props.id).then((res) => {
      toast.success("Game removed from favorite");
      setProgress(100);
      setIsFav(false);
    });
  };

  return (
    <>
      <LoadingBarComponent progress={progress} setProgress={setProgress} />
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
    </>
  );
}
