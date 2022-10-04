import * as React from "react";
import Popover from "@mui/material/Popover";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import { useState } from "react";
import GenreService from "../../api/GenreService";
import DeveloperService from "../../api/DeveloperService";
import PlatformService from "../../api/PlatformService";
import { useEffect } from "react";
import GameService from "../../api/GameService";
import { useParams } from "react-router";
import { Menu, MenuItem } from "@mui/material";

export default function GameAddPopover(props) {
  const [data, setData] = useState([]);
  const params = useParams();

  useEffect(() => {
    getData();
  }, []);

  const getData = () => {
    if (props.type === "genre") {
      GenreService.getGenres().then((res) => {
        setData(res.data);
      });
    }

    if (props.type === "developer") {
      DeveloperService.getDevelopers().then((res) => {
        setData(res.data);
      });
    }

    if (props.type === "platform") {
      PlatformService.getPlatforms().then((res) => {
        setData(res.data);
      });
    }
  };

  const handleDataPost = (id) => {
    if (props.type === "genre") {
      GameService.AddGenre(params.id, id).then((res) => {
        handleClose();
        props.getGame();
      });
    }

    if (props.type === "developer") {
      GameService.AddDeveloper(params.id, id).then((res) => {
        handleClose();
        props.getGame();
      });
    }

    if (props.type === "platform") {
      GameService.AddPlatform(params.id, id).then((res) => {
        handleClose();
        props.getGame();
      });
    }
  };

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
        <Menu
          id="basic-menu"
          anchorEl={props.anchorEl}
          open={open}
          onClose={handleClose}
          MenuListProps={{
            "aria-labelledby": "basic-button",
          }}
          sx={{ maxHeight: "300px" }}
        >
          {data.map((element) => {
            return (
              <MenuItem
                onClick={() => handleDataPost(element.id)}
                key={element.id}
              >
                {element.name}
              </MenuItem>
            );
          })}
        </Menu>
      </Popover>
    </div>
  );
}
