const WebSocket = require('ws');

let password = '';
let port = 0;

process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";

let ws = new WebSocket(`wss://riot:${password}@127.0.0.1:${port}/`, "wamp");

ws.on('error', (err) => {
    console.log(err);
});

ws.on('message', (msg) => {
    console.log(msg);
});

ws.on('open', () => {
    ws.send('[5, "OnJsonApiEvent"]');
    ws.send('[5, "OnCallback"]');

    // Not sure if OnJsonApiEvent already subscribes to the events below
    // ws.send('[5, "OnJsonApiEvent_lol-champ-select_v1_session"]');
    // ws.send('[5, "OnJsonApiEvent_lol-champ-select-legacy_v1_session"]');
    // ws.send('[5, "OnJsonApiEvent_lol-champ-select-legacy_v1_pickable-champions"]');
    // ws.send('[5, "OnJsonApiEvent_lol-champ-select-legacy_v1_implementation-active"]');
});
