import * as React from "react";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import IconButton from "@mui/material/IconButton";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import DeveloperService from "../../api/DeveloperService";
export default function DevelopersList(props) {
    
  const handleDelete = () => {
    DeveloperService.deleteDeveloper(props.developer.id).then((res) => {
      props.getDevelopers();
    });
  };

  return (
    <ListItem
      key={props.developer.id}
      secondaryAction={
        <IconButton onClick={handleDelete} aria-label="comment">
          <DeleteForeverIcon />
        </IconButton>
      }
    >
      <ListItemText
        primary={`${props.developer.name}`}
        secondary={props.developer.headquarters}
      />
    </ListItem>
  );
}
