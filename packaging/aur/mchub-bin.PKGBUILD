# Maintainer: tiouoo <tiouo@qq.com>

pkgname=mchub-bin
pkgver=0.0.0.0
pkgrel=1
pkgdesc="MChub - Minecraft launcher/manager (stable release)"
arch=('x86_64')
url="https://codehub-develop.github.io/MChub/"
license=('GPL-3.0-or-later')
depends=('fuse2' 'hicolor-icon-theme' 'xdg-utils')
provides=("mchub=$pkgver")
conflicts=('mchub' 'mchub-commit-bin' 'mchub-nightly-bin')
options=('!strip' '!emptydirs')
_appimg="MChub.AppImage"
source_x86_64=(
    "$_appimg::https://github.com/CodeHub-develop/MChub/releases/latest/download/MChub.linux.x64.AppImage"
    "mchub.png::https://raw.githubusercontent.com/CodeHub-develop/MChub/main/assets/MChub.png"
)
sha256sums_x86_64=('SKIP' 'SKIP')
noextract=("$_appimg")

package() {
    install -Dm755 "$srcdir/$_appimg" "$pkgdir/opt/mchub/MChub.AppImage"
    install -Dm755 /dev/stdin "$pkgdir/usr/bin/mchub" <<'EOF'
#!/bin/sh
exec /opt/mchub/MChub.AppImage "$@"
EOF
    install -Dm644 "$srcdir/mchub.png" \
        "$pkgdir/usr/share/icons/hicolor/512x512/apps/mchub.png"
    install -Dm644 /dev/stdin "$pkgdir/usr/share/applications/mchub.desktop" <<'EOF'
[Desktop Entry]
Type=Application
Name=MChub
Comment=MChub - Minecraft launcher/manager
Icon=mchub
Exec=mchub %U
Terminal=false
Categories=Game;
MimeType=x-scheme-handler/sl;application/zip;application/x-zip-compressed;
EOF
}