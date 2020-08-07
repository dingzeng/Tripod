import Cookies from 'js-cookie'

const TokenKey = 'Admin-Token'
const MenuKey = 'Admin-Menus'
const PermissionsKey = 'Admin-Permissions'

export function getToken() {
  return Cookies.get(TokenKey)
}

export function setToken(token) {
  return Cookies.set(TokenKey, token)
}

export function removeToken() {
  return Cookies.remove(TokenKey)
}

export function setMenus(menus) {
  localStorage.setItem(MenuKey, JSON.stringify(menus))
}

export function getMenus() {
  const item = localStorage.getItem(MenuKey)
  return item ? JSON.parse(item) : []
}

export function setPermissions(permissions) {
  localStorage.setItem(PermissionsKey, JSON.stringify(permissions))
}

export function getPermissions() {
  const item = localStorage.getItem(PermissionsKey)
  return item ? JSON.parse(item) : []
}
