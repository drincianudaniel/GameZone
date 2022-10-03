import { Chip } from "@mui/material";
import * as React from "react";
import { useParams } from "react-router";
import { toast } from "react-toastify";
import GameService from "../../api/GameService";
import { useUser } from "../../hooks/useUser";

export default function GameChip(props) {
  const params = useParams();

  const handleDelete = () => {
    if (props.type === "genre") {
      GameService.RemoveGenre(params.id, props.data.id).then((res) => {
        toast.success(res.data);
        props.getGame();
      });
    }

    if (props.type === "developer") {
      GameService.RemoveDeveloper(params.id, props.data.id).then((res) => {
        toast.success(res.data);
        props.getGame();
      });
    }

    if (props.type === "platform") {
      GameService.RemovePlatform(params.id, props.data.id).then((res) => {
        toast.success(res.data);
        props.getGame();
      });
    }
  };

  const { user } = useUser();
  
  return (
    <>
      {!user.IsAdmin && (
        <Chip
          sx={{ mt: 0.2, mr: 0.2 }}
          key={props.data.id}
          label={props.data.name}
        />
      )}
      {user.IsAdmin && (
        <Chip
          sx={{ mt: 0.2, mr: 0.2 }}
          key={props.data.id}
          label={props.data.name}
          onDelete={handleDelete}
        />
      )}
    </>
  );
}
