<template>
  <main>
    <div id="app">
      <router-view :key="$route.path" />
    </div>
  </main>
</template>

<style>
/**************************************************************************************************/

/* Button */

a.button,
button.button {
  -webkit-appearance: none;
  appearance: none;
  background: #00b2d5;
  border: none;
  border-radius: 999px;
  box-sizing: border-box;
  color: #fff;
  cursor: pointer;
  display: inline-block;
  font: normal 14px "Poppins", sans-serif;
  letter-spacing: 0;
  line-height: 36px;
  outline: none;
  padding: 0 15px;
  text-decoration: none;
  transition: background-color ease-in-out 150ms, border-color ease-in-out 150ms,
    box-shadow ease-in-out 150ms, color ease-in-out 150ms;
}

a.button:hover,
button.button:hover {
  box-shadow: 0px 3px 6px #00000029;
  text-decoration: none;
}

a.button:active,
button.button:active {
  background: #00a0bf;
  box-shadow: none;
  transition: none;
}

a.button.hollow,
button.button.hollow {
  background: transparent;
  border: 1px solid #00b2d5;
  color: #00b2d5;
  line-height: 34px;
  padding: 0 14px;
}

a.button.hollow:hover,
button.button.hollow:hover {
  background: #00b2d5;
  color: #fff;
}

a.button.hollow:active,
button.button.hollow:active {
  background: #00a0bf;
  color: #fff;
}

/**************************************************************************************************/

/* Checkbox */

span.checkbox > input {
  -webkit-appearance: none;
  appearance: none;
  background: url("data:image/svg+xml,<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' viewBox='0 0 16 16'><rect x='0.5' y='0.5' width='15' height='15' rx='3' fill='%23f9f9fc' /><rect x='0.5' y='0.5' width='15' height='15' rx='3' fill='none' stroke='%23a6aec1' stroke-width='1' /></svg>");
  border-radius: 3px;
  box-shadow: 0px 1px 1px #131f151a;
  box-sizing: border-box;
  content: "";
  cursor: pointer;
  display: inline-block;
  flex-shrink: 0;
  height: 16px;
  transition: background-color ease-in-out 150ms,
    background-image ease-in-out 150ms, border-color ease-in-out 150ms;
  vertical-align: -3px;
  width: 16px;
}

span.checkbox > input:checked {
  background: url("data:image/svg+xml,<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' viewBox='0 0 16 16'><rect x='0.5' y='0.5' width='15' height='15' rx='3' fill='%2300b2d5bf' /><rect x='0.5' y='0.5' width='15' height='15' rx='3' fill='none' stroke='%2300b2d5' stroke-width='1' /><path d='M 6.652 10.894 l -2.545 -2.563 a 0.362 0.362 0 0 1 0 -0.513 l 0.514 -0.513 a 0.366 0.366 0 0 1 0.514 0 l 1.775 1.794 3.956 -3.994 a 0.365 0.365 0 0 1 0.514 0 l 0.514 0.513 a 0.361 0.361 0 0 1 0 0.511 l -4.728 4.764 a 0.366 0.366 0 0 1 -0.514 0' fill='%23fff' /></svg>");
}

/**************************************************************************************************/

/* Dialogue */

div.dialogue {
  height: 100%;
  left: 0;
  overflow-x: hidden;
  overflow-y: auto;
  position: fixed;
  top: 0;
  width: 100%;
  z-index: 7000;
}

div.dialogue > div {
  background: #ffffff;
  border-radius: 6px;
  box-shadow: 0px 5px 15px #00000026;
  box-sizing: border-box;
  display: flex;
  flex-direction: column;
  margin: 25px auto;
  max-height: calc(100vh - 50px);
  min-height: 250px;
  padding-top: 25px;
}

div.dialogue > div > div.body {
  flex-shrink: 1;
  margin-bottom: 25px;
  overflow-x: hidden;
  overflow-y: auto;
  padding: 25px 25px 0 25px;
}

div.dialogue > div > div.footer {
  flex-shrink: 0;
  padding: 0 25px 0 25px;
}

div.dialogue > div > div.header {
  flex-shrink: 0;
  padding: 0 25px 0 25px;
}

div.dialogue > div > div.header > a.close {
  background: url("data:image/svg+xml,<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' viewBox='0 0 16 16'><path d='M35.881,34l5.733-5.715a1.333,1.333,0,1,0-1.893-1.878L34,32.108l-5.719-5.714a1.333,1.333,0,0,0-1.893,1.878L32.121,34l-5.732,5.728a1.333,1.333,0,1,0,1.893,1.878L34,35.879l5.719,5.715a1.333,1.333,0,1,0,1.893-1.878Z' fill='%232c2c2c' transform='translate(-26.002 -26)' /></svg>")
    center center no-repeat;
  border-radius: 50%;
  display: block;
  float: right;
  height: 36px;
  margin-left: 18px;
  margin-right: -10px;
  margin-top: -3px;
  transition: background-color ease-in-out 250ms;
  width: 36px;
}

div.dialogue > div > div.header > a.close:hover {
  background-color: #2c2c2c14;
}

div.dialogue > div > div.header > a.close:active {
  background-color: #2c2c2c28;
}

div.overlay {
  background: #000000;
  height: 100%;
  left: 0;
  opacity: 0;
  position: fixed;
  top: 0;
  transition: opacity ease-in-out 250ms;
  width: 100%;
  z-index: 6000;
}

div.overlay.visible {
  opacity: 0.25;
}

/**************************************************************************************************/

/* General */

* {
  scrollbar-color: #2c2c2c40 transparent;
  scrollbar-width: thin;
}

a {
  color: #00b2d5;
  text-decoration: none;
}

a:hover {
  text-decoration: underline;
}

body {
  background: #f4f5fa;
  margin: 0;
  padding: 0;
}

fieldset {
  border: none;
  margin: 0 0 25px 0;
  padding: 0;
}

fieldset.required > label::after {
  color: #f2405c;
  content: "Required";
  float: right;
  font: normal 14px "Poppins", sans-serif;
  margin-left: 18px;
}

fieldset > label {
  color: #2c2c2c;
  display: block;
  font: 600 14px "Poppins", sans-serif;
  letter-spacing: 0;
}

fieldset > * + * {
  margin-top: 11px;
}

main {
  box-sizing: border-box;
  margin: 0 auto;
  max-width: 2048px;
  min-width: 1200px;
  padding: 89px 88px 1px 88px;
}

::-webkit-scrollbar {
  background-color: transparent;
  height: 8px;
  width: 8px;
}

::-webkit-scrollbar-thumb {
  background-color: #2c2c2c40;
  border-radius: 4px;
}

::-webkit-scrollbar-track {
  background-color: transparent;
}

.commands {
  align-items: center;
  display: flex;
}

.commands > * + * {
  margin-left: 20px;
}

.grow {
  flex-grow: 1;
}

/**************************************************************************************************/

/* Popup menu */

span.popup_menu {
  background: url("data:image/svg+xml,<svg xmlns='http://www.w3.org/2000/svg' width='4.5' height='16.5' viewBox='0 0 4.5 16.5'><circle cx='2.25' cy='2.25' r='1.25' fill='%23fff' /><circle cx='2.25' cy='8.25' r='1.25' fill='%23fff' /><circle cx='2.25' cy='14.25' r='1.25' fill='%23fff' /></svg>")
    no-repeat center center #00b2d5;
  border-radius: 9999px;
  box-sizing: border-box;
  cursor: pointer;
  display: inline-block;
  height: 36px;
  transition: background-color ease-in-out 150ms, box-shadow ease-in-out 150ms;
  white-space: nowrap;
  width: 36px;
  vertical-align: middle;
}

span.popup_menu:hover {
  box-shadow: 0px 3px 6px #00000029;
}

span.popup_menu.focus {
  background-color: #00a0bf;
  box-shadow: none;
  transition: none;
}

span.popup_menu > span {
  background: #ffffff;
  border-radius: 4px;
  cursor: default;
  box-shadow: 0px 4px 8px #00000014;
  position: fixed;
  text-align: left;
  z-index: 7500;
}

span.popup_menu > span > a {
  border-bottom: 4px solid transparent;
  border-top: 4px solid transparent;
  color: #2c2c2c;
  cursor: pointer;
  display: block;
  font: normal 14px "Poppins", sans-serif;
  margin: 0;
  padding: 5px 15px;
  text-decoration: none;
}

span.popup_menu > span > a:hover {
  background: #00b2d514 padding-box;
  text-decoration: none;
}

/**************************************************************************************************/

/* Snackbar */

div.snackbar {
  align-items: center;
  border-radius: 4px;
  box-shadow: 0px 4px 8px #00000014;
  box-sizing: border-box;
  color: #fff;
  cursor: pointer;
  display: flex;
  font: normal 16px "Poppins", sans-serif;
  margin: 0 0 12.5px 0;
  opacity: 0;
  padding: 10px 15px;
  text-align: center;
  transition: opacity ease-in-out 150ms;
}

div.snackbar::after {
  background: url("data:image/svg+xml,<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' viewBox='0 0 16 16'><path d='M35.881,34l5.733-5.715a1.333,1.333,0,1,0-1.893-1.878L34,32.108l-5.719-5.714a1.333,1.333,0,0,0-1.893,1.878L32.121,34l-5.732,5.728a1.333,1.333,0,1,0,1.893,1.878L34,35.879l5.719,5.715a1.333,1.333,0,1,0,1.893-1.878Z' fill='%23fff' transform='translate(-26.002 -26)' /></svg>")
    center center no-repeat;
  content: "";
  display: block;
  flex-shrink: 0;
  height: 16px;
  margin-left: 15px;
  width: 16px;
}

div.snackbar::before {
  content: "";
  display: block;
  flex-shrink: 0;
  height: 35px;
  margin-right: 15px;
  width: 35px;
}

div.snackbar.error {
  background: #f2405c;
}

div.snackbar.error::before {
  background: url("data:image/svg+xml,<svg xmlns='http://www.w3.org/2000/svg' width='35' height='35' viewBox='0 0 35 35'><circle cx='17.5' cy='17.5' r='16.15' fill='none' stroke='%23fff' stroke-width='2.3px' /><path d='M34.009,15.419Zm1.074,6.673a1.239,1.239,0,0,0-1.229,1.267v9.932a1.242,1.242,0,1,0,2.483,0V23.36a1.242,1.242,0,0,0-1.254-1.267Zm.013,14.1a1.655,1.655,0,1,0,1.655,1.655A1.654,1.654,0,0,0,35.1,36.188Z' fill='%23fff' transform='translate(-17.5965 -13)' /></svg>")
    center center no-repeat;
}

div.snackbar_container {
  align-items: center;
  box-sizing: border-box;
  display: flex;
  flex-direction: column;
  left: 50%;
  margin-right: -50%;
  padding: 12.5px 12.5px 1px 12.5px;
  position: fixed;
  top: 0;
  transform: translate(-50%, 0);
  z-index: 7250;
}

/**************************************************************************************************/

/* Table */

div.table {
  border: 1px solid #e7eaf5;
  border-radius: 6px;
  color: #2c2c2c;
  font: normal 14px "Poppins", sans-serif;
  margin: 0 0 25px 0;
  overflow: auto;
  text-align: left;
  vertical-align: middle;
}

div.table > table {
  border-collapse: collapse;
  width: 100%;
}

div.table > table > tbody {
  background: #ffffff;
}

div.table > table > tbody > tr {
  /* NOTHING */
}

div.table > table > tbody > tr:first-of-type > td {
  border-top: none;
}

div.table > table > tbody > tr > td {
  border-top: 1px solid #e7eaf5;
  padding: 15px 12px;
  transition: background-color ease-in-out 150ms;
}

div.table > table > tbody > tr > td:last-of-type:not(:first-of-type) {
  padding-bottom: 0;
  padding-top: 0;
  text-align: right;
}

div.table
  > table
  > tbody
  > tr
  > td:last-of-type:not(:first-of-type)
  > span.popup_menu {
  background: url("data:image/svg+xml,<svg xmlns='http://www.w3.org/2000/svg' width='4.5' height='16.5' viewBox='0 0 4.5 16.5'><circle cx='2.25' cy='2.25' r='1.25' fill='%23293845' /><circle cx='2.25' cy='8.25' r='1.25' fill='%23293845' /><circle cx='2.25' cy='14.25' r='1.25' fill='%23293845' /></svg>")
    no-repeat center center;
  box-shadow: none;
}

div.table
  > table
  > tbody
  > tr
  > td:last-of-type:not(:first-of-type)
  > span.popup_menu:hover {
  background-color: #00b2d514;
}

div.table
  > table
  > tbody
  > tr
  > td:last-of-type:not(:first-of-type)
  > span.popup_menu.focus {
  background-color: #00a0bf14;
}

div.table > table > tbody > tr > td.numeric {
  text-align: right;
}

div.table > table > tbody > tr > td.sorted {
  /* NOTHING */
}

div.table > table > tbody > tr:not(.info):hover > td {
  background: #00b2d514;
}

div.table > table > thead {
  text-transform: uppercase;
  white-space: nowrap;
}

div.table > table > thead > tr {
  /* NOTHING */
}

div.table > table > thead > tr > th {
  background: #e7eaf5;
  font-weight: 600;
  padding: 12px;
}

div.table > table > thead > tr > th:last-of-type {
}

div.table > table > thead > tr > th.numeric {
  text-align: right;
}

div.table > table > thead > tr + tr > th {
  padding-top: 0;
}

/**************************************************************************************************/

/* Text box */

fieldset > textarea.text {
  width: 100%;
}

textarea.text {
  background: #fcfcfc;
  border: 1px solid #a6aec1;
  border-radius: 4px;
  box-sizing: border-box;
  color: #2c2c2c;
  display: inline-block;
  font: normal 14px "Poppins", sans-serif;
  outline: none;
  padding: 8px 14px;
  transition: background-color ease-in-out 150ms, border-color ease-in-out 150ms;
  resize: vertical;
  width: 250px;
}

textarea.text:focus {
  background: #ffffff;
  border: 1px solid #00b2d5;
}

textarea.text:hover {
  background: #ffffff;
}

/**************************************************************************************************/

/* Typography */

h1 {
  color: #2c2c2c;
  font: 600 26px "Poppins", sans-serif;
  letter-spacing: 0;
  margin: 0 0 25px 0;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

h2 {
  color: #2c2c2c;
  font: 600 20px "Poppins", sans-serif;
  letter-spacing: 0;
  margin: 0 0 25px 0;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}
</style>
