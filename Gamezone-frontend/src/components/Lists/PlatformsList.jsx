import * as React from "react";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import IconButton from "@mui/material/IconButton";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import DeveloperService from "../../api/DeveloperService";
import PlatformService from "../../api/PlatformService";
export default function PlatformsList(props) {
    
  const handleDelete = () => {
    PlatformService.deletePlatform(props.platform.id).then((res) => {
      props.getPlatforms();
    });
  };

  return (
    <ListItem
      key={props.platform.id}
      secondaryAction={
        <IconButton onClick={handleDelete} aria-label="comment">
          <DeleteForeverIcon />
        </IconButton>
      }
    >
      <ListItemText
        primary={`${props.platform.name}`}
      />
    </ListItem>
  );
}
