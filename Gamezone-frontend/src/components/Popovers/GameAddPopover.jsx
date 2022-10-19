import * as React from "react";
import Popover from "@mui/material/Popover";
import { useState } from "react";
import GenreService from "../../api/GenreService";
import DeveloperService from "../../api/DeveloperService";
import PlatformService from "../../api/PlatformService";
import { useEffect } from "react";
import GameService from "../../api/GameService";
import { useParams } from "react-router";
import { Menu, MenuItem } from "@mui/material";
import { toast } from "react-toastify";

export default function GameAddPopover(props) {
  const [data, setData] = useState([]);
  const params = useParams();

  useEffect(() => {
    getData();
  }, [props.presentData]);

  const getData = async () => {
    if (props.type === "genre") {
      await GenreService.getGenres().then((res) => {
        var newArr = res.data;
        console.log(props.presentData)
        if (props.presentData !== undefined) {
          newArr = res.data.filter(
            (el) => !props.presentData.find((e) => e.id === el.id)
          );
        }
        setData(newArr);
      });
    }

    if (props.type === "developer") {
      await DeveloperService.getDevelopers().then((res) => {
        var newArr = res.data;
        if (props.presentData !== undefined) {
          newArr = res.data.filter(
            (el) => !props.presentData.find((e) => e.id === el.id)
          );
        }
        setData(newArr);
      });
    }

    if (props.type === "platform") {
      await PlatformService.getPlatforms().then((res) => {
        var newArr = res.data;
        if (props.presentData !== undefined) {
          newArr = res.data.filter(
            (el) => !props.presentData.find((e) => e.id === el.id)
          );
        }
        setData(newArr);
      });
    }
    // props.presentData.map(pd=>{
    //   list = data.filter(d => d.id !== pd.id)
    // })
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
