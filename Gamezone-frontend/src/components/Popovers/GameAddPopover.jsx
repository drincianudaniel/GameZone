import * as React from "react";
import Popover from "@mui/material/Popover";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";

export default function GameAddPopover(props) {
  const handleClose = () => {
    props.setAnchorEl(null);
  };

  const open = Boolean(props.anchorEl);
  const id = open ? "simple-popover" : undefined;

  return (
    <div>
      <Popover
        id={id}
        open={open}
        anchorEl={props.anchorEl}
        onClose={handleClose}
        anchorOrigin={{
          vertical: "bottom",
          horizontal: "left",
        }}
      >
        {props.type === "developer" && (
          <Typography sx={{ p: 2 }}>The content of the developer.</Typography>
        )}

        {props.type === "genre" && (
          <Typography sx={{ p: 2 }}>The content of the genre.</Typography>
        )}

        {props.type === "platform" && (
          <Typography sx={{ p: 2 }}>The content of the platform.</Typography>
        )}
        
      </Popover>
    </div>
  );
}
