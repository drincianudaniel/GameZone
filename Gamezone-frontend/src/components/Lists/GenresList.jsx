import * as React from "react";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import IconButton from "@mui/material/IconButton";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import GenreService from "../../api/GenreService";

export default function GenresList(props) {
  
  const handleDelete = () => {
    GenreService.deleteGenre(props.genre.id).then((res) => {
      props.getGenres();
    });
  };

  return (
    <ListItem
      key={props.genre.id}
      secondaryAction={
        <IconButton onClick={handleDelete} aria-label="comment">
          <DeleteForeverIcon />
        </IconButton>
      }
    >
      <ListItemText primary={`${props.genre.name}`} />
    </ListItem>
  );
}
