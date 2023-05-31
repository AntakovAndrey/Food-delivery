import React, { useRef, useEffect, useState } from 'react';
import mapboxgl from '!mapbox-gl'; // eslint-disable-line import/no-webpack-loader-syntax
import styles from "./Map.module.css"

import 'mapbox-gl/dist/mapbox-gl.css';




const Map = () => {
  mapboxgl.accessToken = 'pk.eyJ1IjoiYW5kcmV5YW50YWtvdiIsImEiOiJjbGZjbnRpNnQzY2N4M29yMHhkbzJjZ25wIn0.Yj7BV-EJ_lFEPqqgPXigow';
  const mapContainer = useRef(null);
  const map = useRef(null);
  // eslint-disable-next-line
  const [lng, setLng] = useState(27.9);
  // eslint-disable-next-line
  const [lat, setLat] = useState(53.35);
  // eslint-disable-next-line
  const [zoom, setZoom] = useState(9);

  useEffect(() => {
    if (map.current) return; // initialize map only once
    map.current = new mapboxgl.Map({
    container: mapContainer.current,
    style: 'mapbox://styles/andreyantakov/clfco6cdn00fx01mxi274aig9',
    center: [lng, lat],
    zoom: zoom
    });
    });

  /*const mapContainer = useRef(null);
  const map = useRef(null);
  const [lng, setLng] = useState(-70.9);
  const [lat, setLat] = useState(42.35);
  const [zoom, setZoom] = useState(9);*/

  /*useEffect(() => {
    if (map.current) return; // initialize map only once
    map.current = new mapboxgl.Map({
    container: mapContainer.current,
    style: 'mapbox://styles/mapbox/streets-v12',
    center: [lng, lat],
    zoom: zoom
    });
    });*/ 

  /*const [viewport, setViewport] = React.useState({
    width: '100%',
    height: 400,
    latitude: 37.7577,
    longitude: -122.4376,
    zoom: 8
  });*/

  return (
      <div ref={mapContainer} className={styles.map_container} />
    
  );
};

export default Map;