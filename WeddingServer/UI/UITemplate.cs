namespace WeddingServer.UI
{
    public static class UITemplate
    {
        public static string GetWeddingCard(string guestName)
        {
            return WeddingCard.Replace("{{GUEST_NAME}}", System.Net.WebUtility.HtmlEncode(guestName));
        }
        public const string WeddingCard = $@"<!DOCTYPE html>
<html lang=""vi"">
<head>
  <meta charset=""UTF-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
  <title>Thiệp Cưới - Hoàng Sơn & Kim Phượng</title>
  <script src=""https://cdn.tailwindcss.com""></script>
  <link href=""https://fonts.googleapis.com/css2?family=Playfair+Display:wght@400;600;700;800&family=Quicksand:wght@300;400;500;600;700&family=Dancing+Script:wght@400;600;700&display=swap"" rel=""stylesheet"">
  <style>
    * {{
      margin: 0;
      padding: 0;
      box-sizing: border-box;
      scroll-behavior: smooth;
    }}

    body {{
      font-family: 'Quicksand', sans-serif;
      background: linear-gradient(135deg, #fff5f7 0%, #ffe5f1 25%, #fff0f8 50%, #fce4ec 75%, #fff5f7 100%);
      background-size: 400% 400%;
      animation: gradientShift 20s ease infinite;
      overflow-x: hidden;
    }}

    @keyframes gradientShift {{
      0%, 100% {{ background-position: 0% 50%; }}
      50% {{ background-position: 100% 50%; }}
    }}

    h1, h2, h3 {{ font-family: 'Playfair Display', serif; }}

    /* ===== FALLING PETALS ===== */
    .petal {{
      position: fixed;
      width: 12px;
      height: 12px;
      background: radial-gradient(circle, #ffb3d9, #ff80bf);
      border-radius: 50% 0 50% 0;
      pointer-events: none;
      animation: fall linear infinite;
      opacity: 0;
      z-index: 9999;
      filter: blur(0.5px);
    }}

    @keyframes fall {{
      0% {{ opacity: 0; transform: translateY(-10px) rotate(0deg); }}
      10% {{ opacity: 0.9; }}
      90% {{ opacity: 0.4; }}
      100% {{ opacity: 0; transform: translateY(100vh) rotate(720deg); }}
    }}

    /* ===== HERO SECTION ===== */
    .hero {{
      min-height: 100vh;
      display: flex;
      align-items: center;
      justify-content: center;
      flex-direction: column;
      text-align: center;
      position: relative;
      overflow: hidden;
      background: linear-gradient(
          rgba(255, 182, 193, 0.4),
          rgba(255, 192, 203, 0.5)
        ),
        url(""https://images.unsplash.com/photo-1519741497674-611481863552?w=800"") center/cover no-repeat;
    }}

    .hero::before {{
      content: """";
      position: absolute;
      top: -50%;
      left: -50%;
      width: 200%;
      height: 200%;
      background: radial-gradient(circle, rgba(255, 255, 255, 0.15), transparent 70%);
      animation: rotate 40s linear infinite;
    }}

    @keyframes rotate {{
      100% {{ transform: rotate(360deg); }}
    }}

    .hero-content {{
      position: relative;
      z-index: 10;
      animation: fadeInUp 1.8s ease-out;
    }}

    .hero h1 {{
      font-size: clamp(2.5rem, 8vw, 5rem);
      color: #fff;
      text-shadow: 4px 4px 12px rgba(0, 0, 0, 0.5);
      letter-spacing: 2px;
      animation: fadeIn 2.5s ease-in-out;
      font-weight: 800;
    }}

    .hero p {{
      color: #fff;
      font-weight: 400;
      text-shadow: 2px 2px 6px rgba(0, 0, 0, 0.5);
      font-size: clamp(1.2rem, 3vw, 1.5rem);
    }}

    .hero-icon {{
      animation: heartbeat 1.5s ease-in-out infinite;
    }}

    @keyframes heartbeat {{
      0%, 100% {{ transform: scale(1); }}
      50% {{ transform: scale(1.1); }}
    }}

    @keyframes fadeInUp {{
      from {{ opacity: 0; transform: translateY(50px); }}
      to {{ opacity: 1; transform: translateY(0); }}
    }}

    @keyframes fadeIn {{
      from {{ opacity: 0; }}
      to {{ opacity: 1; }}
    }}

    /* ===== SCROLL INDICATOR ===== */
    .scroll-indicator {{
      position: absolute;
      bottom: 30px;
      left: 50%;
      transform: translateX(-50%);
      animation: bounce 2s infinite;
      cursor: pointer;
      z-index: 20;
    }}

    @keyframes bounce {{
      0%, 100% {{ transform: translateX(-50%) translateY(0); }}
      50% {{ transform: translateX(-50%) translateY(-15px); }}
    }}

    /* ===== INVITATION SECTION ===== */
    .invitation-section {{
      background: linear-gradient(180deg, #fff8fb 0%, #ffe2ee 50%, #fff8fb 100%);
      padding: 6rem 1.5rem;
      position: relative;
      overflow: hidden;
    }}

    .invitation-section::before {{
      content: """";
      position: absolute;
      top: -50px;
      left: 0;
      width: 100%;
      height: 100px;
      background: radial-gradient(ellipse at top, rgba(255, 182, 193, 0.3), transparent);
    }}

    .invitation-section::after {{
      content: ""💕"";
      position: absolute;
      font-size: 15rem;
      opacity: 0.05;
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);
      pointer-events: none;
      z-index: 0;
    }}

    .invitation-content {{
      position: relative;
      z-index: 1;
    }}

    .invitation-title {{
      opacity: 0;
      animation: fadeInDown 1s ease-out 0.2s forwards;
    }}

    .invitation-greeting {{
      opacity: 0;
      animation: fadeInUp 1s ease-out 0.4s forwards;
    }}

    .invitation-message {{
      opacity: 0;
      animation: fadeInUp 1s ease-out 0.6s forwards;
    }}

    .event-details {{
      opacity: 0;
      animation: zoomIn 1s ease-out 0.8s forwards;
    }}

    .location-details {{
      opacity: 0;
      animation: fadeInUp 1s ease-out 1s forwards;
    }}

    @keyframes fadeInDown {{
      from {{
        opacity: 0;
        transform: translateY(-30px);
      }}
      to {{
        opacity: 1;
        transform: translateY(0);
      }}
    }}

    @keyframes zoomIn {{
      from {{
        opacity: 0;
        transform: scale(0.8);
      }}
      to {{
        opacity: 1;
        transform: scale(1);
      }}
    }}

    .date-badge {{
      display: inline-block;
      background: linear-gradient(135deg, #ff69b4, #ff1493);
      color: white;
      padding: 1rem 2.5rem;
      border-radius: 50px;
      font-weight: 700;
      box-shadow: 0 10px 30px rgba(255, 105, 180, 0.3);
      transition: all 0.3s ease;
      animation: float 3s ease-in-out infinite;
    }}

    .date-badge:hover {{
      transform: translateY(-5px);
      box-shadow: 0 15px 40px rgba(255, 105, 180, 0.5);
    }}

    @keyframes float {{
      0%, 100% {{
        transform: translateY(0);
      }}
      50% {{
        transform: translateY(-10px);
      }}
    }}

    .time-badge {{
      display: inline-flex;
      align-items: center;
      gap: 0.5rem;
      background: white;
      padding: 0.75rem 2rem;
      border-radius: 50px;
      box-shadow: 0 5px 20px rgba(255, 105, 180, 0.15);
      transition: all 0.3s ease;
    }}

    .time-badge:hover {{
      transform: scale(1.05);
      box-shadow: 0 8px 25px rgba(255, 105, 180, 0.25);
    }}

    .location-card {{
      background: rgba(255, 255, 255, 0.6);
      backdrop-filter: blur(10px);
      padding: 2rem;
      border-radius: 25px;
      border: 2px solid rgba(255, 192, 203, 0.3);
      transition: all 0.4s ease;
      box-shadow: 0 10px 30px rgba(255, 105, 180, 0.1);
    }}

    .location-card:hover {{
      transform: translateY(-5px);
      box-shadow: 0 15px 40px rgba(255, 105, 180, 0.2);
      border-color: rgba(255, 192, 203, 0.5);
    }}

    .divider-ornament {{
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 1rem;
      margin: 2rem 0;
    }}

    .divider-ornament::before,
    .divider-ornament::after {{
      content: '';
      flex: 1;
      height: 2px;
      background: linear-gradient(90deg, transparent, rgba(255, 105, 180, 0.3), transparent);
    }}

    .ornament-icon {{
      font-size: 2rem;
      animation: rotate 10s linear infinite;
    }}

    @keyframes rotate {{
      from {{ transform: rotate(0deg); }}
      to {{ transform: rotate(360deg); }}
    }}

    /* ===== COUNTDOWN ===== */
    .countdown-item {{
      background: linear-gradient(135deg, #fff 0%, #ffe5f1 100%);
      border-radius: 20px;
      padding: 1.5rem;
      min-width: 90px;
      box-shadow: 0 10px 30px rgba(255, 105, 180, 0.2);
      transition: all 0.3s ease;
      animation: pulse 3s ease-in-out infinite;
    }}

    .countdown-item:hover {{
      transform: translateY(-5px) scale(1.05);
      box-shadow: 0 15px 40px rgba(255, 105, 180, 0.35);
    }}

    @keyframes pulse {{
      0%, 100% {{ transform: scale(1); }}
      50% {{ transform: scale(1.03); }}
    }}

    /* ===== TIMELINE ===== */
    .timeline-item {{
      opacity: 0;
      transform: translateX(-80px);
      animation: slideInLeft 1s ease-out forwards;
    }}

    .timeline-item:nth-child(even) {{
      transform: translateX(80px);
      animation: slideInRight 1s ease-out forwards;
    }}

    @keyframes slideInLeft {{
      to {{ opacity: 1; transform: translateX(0); }}
    }}

    @keyframes slideInRight {{
      to {{ opacity: 1; transform: translateX(0); }}
    }}

    /* ===== GALLERY ===== */
/* 🌸 Wedding Gallery – Soft & Elegant Style */
.gallery-section {{
  background: linear-gradient(180deg, #fffafc, #fff0f6);
  padding: 4rem 2rem;
  position: relative;
  overflow: hidden;
}}

.gallery-section::before {{
  content: """";
  position: absolute;
  inset: 0;
  background: url('https://cdn.pixabay.com/photo/2016/11/29/09/32/rose-1869621_960_720.jpg') center/cover no-repeat;
  opacity: 0.05;
  z-index: 0;
}}

/* 🌿 Layout: Masonry with variable sizes */
.gallery-grid {{
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(240px, 1fr));
  gap: 1.5rem;
  position: relative;
  z-index: 1;
}}

.gallery-item {{
  position: relative;
  border-radius: 1.5rem;
  overflow: hidden;
  box-shadow: 0 10px 25px rgba(255, 150, 180, 0.25);
  transform: translateY(0);
  transition: transform 0.6s cubic-bezier(0.19, 1, 0.22, 1), box-shadow 0.4s ease;
  cursor: pointer;
}}

.gallery-item img {{
  width: 100%;
  height: 100%;
  object-fit: cover;
  transition: transform 0.8s ease;
}}

.gallery-item:hover {{
  transform: translateY(-10px) scale(1.03);
  box-shadow: 0 15px 35px rgba(255, 160, 190, 0.4);
}}

.gallery-item:hover img {{
  transform: scale(1.1);
}}

.gallery-overlay {{
  position: absolute;
  inset: 0;
  background: linear-gradient(to top, rgba(255, 160, 190, 0.65), transparent);
  color: white;
  font-weight: 600;
  display: flex;
  align-items: flex-end;
  justify-content: center;
  padding-bottom: 1rem;
  font-size: 1.1rem;
  letter-spacing: 0.5px;
  opacity: 0;
  transition: opacity 0.4s ease;
}}

.gallery-item:hover .gallery-overlay {{
  opacity: 1;
}}

/* 🌷 Floating animation subtle for romance */
@keyframes floatSoft {{
  0% {{ transform: translateY(0px); }}
  50% {{ transform: translateY(-8px); }}
  100% {{ transform: translateY(0px); }}
}}

.gallery-item:nth-child(odd) {{
  animation: floatSoft 6s ease-in-out infinite;
}}
.gallery-item:nth-child(even) {{
  animation: floatSoft 7s ease-in-out infinite reverse;
}}

/* 💫 Album Modal */
.album-modal {{
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.85);
  backdrop-filter: blur(6px);
  display: flex;
  align-items: center;
  justify-content: center;
  visibility: hidden;
  opacity: 0;
  z-index: 999;
  transition: opacity 0.3s ease, visibility 0.3s ease;
}}

.album-modal.active {{
  visibility: visible;
  opacity: 1;
}}

.album-content {{
  position: relative;
  max-width: 85%;
  max-height: 85%;
  border-radius: 1.5rem;
  overflow: hidden;
  box-shadow: 0 0 40px rgba(255, 150, 180, 0.5);
}}

.album-slide {{
  width: 100%;
  height: auto;
  border-radius: inherit;
  animation: fadeIn 0.5s ease;
}}

@keyframes fadeIn {{
  from {{ opacity: 0; transform: scale(0.96); }}
  to {{ opacity: 1; transform: scale(1); }}
}}

/* 🎀 Navigation Buttons */
.album-nav {{
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  background: rgba(255, 255, 255, 0.25);
  color: #fff;
  border: none;
  font-size: 2.2rem;
  cursor: pointer;
  border-radius: 50%;
  padding: 0.5rem 0.9rem;
  transition: background 0.3s, transform 0.3s;
  backdrop-filter: blur(6px);
}}

.album-nav:hover {{
  background: rgba(255, 255, 255, 0.5);
  transform: scale(1.15);
}}

.album-nav.prev {{ left: -3rem; }}
.album-nav.next {{ right: -3rem; }}

.album-close {{
  position: absolute;
  top: -2rem;
  right: -2rem;
  background: rgba(255, 255, 255, 0.3);
  color: #fff;
  border: none;
  font-size: 2rem;
  border-radius: 50%;
  width: 2.5rem;
  height: 2.5rem;
  cursor: pointer;
  line-height: 1;
  transition: background 0.3s, transform 0.3s;
}}

.album-close:hover {{
  background: rgba(255, 255, 255, 0.6);
  transform: rotate(90deg);
}}

.album-counter {{
  position: absolute;
  bottom: -2.5rem;
  width: 100%;
  text-align: center;
  color: #fff;
  font-weight: 500;
  font-size: 1rem;
  letter-spacing: 0.3px;
}}



    /* ===== BUTTONS ===== */
    .rsvp-btn {{
      position: relative;
      overflow: hidden;
      transition: all 0.4s ease;
      box-shadow: 0 8px 25px rgba(0, 0, 0, 0.15);
    }}

    .rsvp-btn::before {{
      content: '';
      position: absolute;
      top: 50%;
      left: 50%;
      width: 0;
      height: 0;
      border-radius: 50%;
      background: rgba(255, 255, 255, 0.4);
      transform: translate(-50%, -50%);
      transition: width 0.6s, height 0.6s;
    }}

    .rsvp-btn:hover::before {{
      width: 400px;
      height: 400px;
    }}

    .rsvp-btn:hover {{
      transform: translateY(-5px);
      box-shadow: 0 12px 35px rgba(0, 0, 0, 0.25);
    }}

    .rsvp-btn:active {{
      transform: translateY(-2px) scale(0.98);
    }}

    /* ===== HEART ANIMATION ===== */
    .heart-float {{
      position: fixed;
      color: #ff69b4;
      font-size: 28px;
      pointer-events: none;
      animation: floatHeart 3.5s ease-out forwards;
      z-index: 9999;
    }}

    @keyframes floatHeart {{
      0% {{ opacity: 1; transform: translateY(0) scale(1) rotate(0deg); }}
      100% {{ opacity: 0; transform: translateY(-250px) scale(1.8) rotate(180deg); }}
    }}

    /* ===== FORM INPUTS ===== */
    input, textarea {{
      transition: all 0.4s ease;
      border: 2px solid transparent;
    }}

    input:focus, textarea:focus {{
      outline: none;
      border-color: #ff69b4;
      box-shadow: 0 0 0 5px rgba(255, 105, 180, 0.12);
      transform: translateY(-3px);
      background: white;
    }}

    /* ===== MUSIC CONTROL ===== */
    .music-control {{
      position: fixed;
      bottom: 30px;
      right: 30px;
      width: 65px;
      height: 65px;
      background: linear-gradient(135deg, #ff69b4, #ff1493);
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      cursor: pointer;
      box-shadow: 0 12px 35px rgba(255, 105, 180, 0.5);
      transition: all 0.4s ease;
      z-index: 10000;
      animation: musicPulse 2.5s ease-in-out infinite;
    }}

    @keyframes musicPulse {{
      0%, 100% {{ box-shadow: 0 12px 35px rgba(255, 105, 180, 0.5); }}
      50% {{ box-shadow: 0 12px 50px rgba(255, 105, 180, 0.7), 0 0 0 15px rgba(255, 105, 180, 0.1); }}
    }}

    .music-control:hover {{
      transform: scale(1.15);
    }}

    .music-control.paused {{
      animation: none;
      background: linear-gradient(135deg, #999, #666);
    }}

    /* ===== ALBUM MODAL ===== */
    .album-modal {{
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.85);
  display: flex;
  align-items: center;
  justify-content: center;
  visibility: hidden;
  opacity: 0;
  z-index: 100;
  transition: opacity 0.35s ease, visibility 0.35s ease;
  backdrop-filter: blur(10px);
}}

.album-modal.active {{
  visibility: visible;
  opacity: 1;
}}

.album-content {{
  position: relative;
  width: 90%;
  max-width: 900px;
  aspect-ratio: 4 / 3; /* khung cố định */
  background: #111;
  border-radius: 16px;
  overflow: hidden;
  box-shadow: 0 10px 30px rgba(0,0,0,0.4);
  display: flex;
  align-items: center;
  justify-content: center;
}}

.album-slide {{
  width: 100%;
  height: 100%;
  object-fit: cover;
  transition: transform 0.6s ease;
  border-radius: 16px;
  animation: fadeIn 0.5s ease;
}}

@keyframes fadeIn {{
  from {{ opacity: 0; transform: scale(0.97); }}
  to {{ opacity: 1; transform: scale(1); }}
}}

.album-nav {{
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  background: rgba(255, 255, 255, 0.25);
  border: none;
  color: white;
  font-size: 2rem;
  cursor: pointer;
  border-radius: 50%;
  width: 55px;
  height: 55px;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: background 0.3s, transform 0.3s;
  z-index: 10;
}}

.album-nav:hover {{
  background: rgba(255, 255, 255, 0.45);
  transform: scale(1.1);
}}

.album-nav.prev {{ left: 20px; }}
.album-nav.next {{ right: 20px; }}

.album-close {{
  position: absolute;
  top: 20px;
  right: 20px;
  background: rgba(255, 255, 255, 0.25);
  border: none;
  color: white;
  font-size: 1.8rem;
  border-radius: 50%;
  width: 50px;
  height: 50px;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: background 0.3s, transform 0.3s;
  z-index: 10;
}}

.album-close:hover {{
  background: rgba(255, 255, 255, 0.5);
  transform: rotate(90deg);
}}

.album-counter {{
  position: absolute;
  bottom: 20px;
  right: 30px;
  color: #fff;
  font-size: 1rem;
  font-weight: 600;
  background: rgba(0,0,0,0.4);
  padding: 6px 14px;
  border-radius: 12px;
  letter-spacing: 1px;
  user-select: none;
  transition: all 0.3s ease;
}}

    /* ===== SECTION HEADERS ===== */
    .section-header {{
      position: relative;
      display: inline-block;
      padding-bottom: 15px;
    }}

    .section-header::after {{
      content: '';
      position: absolute;
      bottom: 0;
      left: 50%;
      transform: translateX(-50%);
      width: 80px;
      height: 4px;
      background: linear-gradient(90deg, transparent, #ff69b4, transparent);
      border-radius: 2px;
    }}

    /* ===== DECORATIVE ELEMENTS ===== */
    .decoration-line {{
      width: 100%;
      height: 2px;
      background: linear-gradient(90deg, transparent, rgba(255, 105, 180, 0.3), transparent);
      margin: 2rem 0;
    }}

    /* ===== RESPONSIVE ===== */
    @media (max-width: 768px) {{
      .countdown-item {{
        min-width: 70px;
        padding: 1.2rem 0.8rem;
      }}
      
      .invitation-card {{
        padding: 2rem 1.5rem !important;
      }}

      .album-content {{
    width: 94%;
    max-width: 100%;
    aspect-ratio: 1 / 1; /* vuông trên mobile */
  }}

  .album-nav {{
    width: 45px;
    height: 45px;
    font-size: 1.6rem;
  }}

  .album-nav.prev {{ left: 10px; }}
  .album-nav.next {{ right: 10px; }}

  .album-close {{
    width: 42px;
    height: 42px;
    top: 10px;
    right: 10px;
  }}

  .album-counter {{
    bottom: 10px;
    right: 50%;
    transform: translateX(50%);
    background: rgba(0,0,0,0.6);
    padding: 4px 10px;
    font-size: 0.9rem;
  }}
      
      .music-control {{
        width: 55px;
        height: 55px;
        bottom: 20px;
        right: 20px;
      }}

      .gallery-item {{
        height: 200px !important;
      }}

      .timeline-item {{
        animation-delay: 0.2s !important;
      }}
    }}

    @media (max-width: 480px) {{
      .countdown-item {{
        min-width: 60px;
        padding: 1rem 0.6rem;
      }}

      .rsvp-btn {{
        padding: 1rem 1.5rem !important;
        font-size: 0.95rem !important;
      }}
    }}

    /* ===== LOADING ANIMATION ===== */
    .loading-overlay {{
      position: fixed;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      background: linear-gradient(135deg, #ffb3d9, #ff80bf);
      display: flex;
      align-items: center;
      justify-content: center;
      z-index: 99999;
      transition: opacity 0.5s ease, visibility 0.5s ease;
    }}

    .loading-overlay.hidden {{
      opacity: 0;
      visibility: hidden;
    }}

    .loading-heart {{
      font-size: 4rem;
      animation: loadingPulse 1s ease-in-out infinite;
    }}

    @keyframes loadingPulse {{
      0%, 100% {{ transform: scale(1); opacity: 1; }}
      50% {{ transform: scale(1.3); opacity: 0.7; }}
    }}
  </style>
</head>
<body>

  <!-- Loading Overlay -->
  <div class=""loading-overlay"" id=""loadingOverlay"">
    <div class=""loading-heart"">💕</div>
  </div>

  <!-- Background Petals -->
  <script>
    function createPetal() {{
      const petal = document.createElement('div');
      petal.className = 'petal';
      petal.style.left = Math.random() * 100 + 'vw';
      petal.style.animationDuration = (Math.random() * 3 + 5) + 's';
      petal.style.animationDelay = Math.random() * 2 + 's';
      petal.style.width = (Math.random() * 8 + 8) + 'px';
      petal.style.height = petal.style.width;
      document.body.appendChild(petal);
      setTimeout(() => petal.remove(), 8000);
    }}
    setInterval(createPetal, 300);
  </script>

  <!-- Background Music -->
  <audio id=""bgMusic"" loop>
    <source src=""https://dangvudev.github.io/my-profile/music.mp3"" type=""audio/mpeg"">
  </audio>

  <!-- Music Control -->
  <div class=""music-control"" id=""musicControl"" title=""Bật/Tắt nhạc"">
    <svg id=""musicIcon"" width=""32"" height=""32"" viewBox=""0 0 24 24"" fill=""white"">
      <path d=""M12 3v10.55c-.59-.34-1.27-.55-2-.55-2.21 0-4 1.79-4 4s1.79 4 4 4 4-1.79 4-4V7h4V3h-6z""/>
    </svg>
  </div>

  <!-- Hero Section -->
  <section class=""hero"" id=""home"">
    <div class=""hero-content px-4"">
      <div class=""hero-icon text-7xl md:text-8xl mb-8"">💕</div>
      <h1 class=""mb-6"">Ngọc Quyên <br>&<br> Hữu Châu</h1>
      <p class=""mb-12"">Chúng tôi kết hôn!</p>
      <div class=""decoration-line max-w-xs mx-auto""></div>
    </div>
    <div class=""scroll-indicator"" onclick=""document.getElementById('invitation').scrollIntoView()"">
      <svg width=""40"" height=""40"" viewBox=""0 0 24 24"" fill=""white"" style=""filter: drop-shadow(0 2px 4px rgba(0,0,0,0.3));"">
        <path d=""M7.41 8.59L12 13.17l4.59-4.58L18 10l-6 6-6-6 1.41-1.41z""/>
      </svg>
    </div>
  </section>

  <!-- Invitation Section -->
  <section class=""invitation-section"" id=""invitation"">
    <div class=""max-w-4xl mx-auto invitation-content text-center px-4"">
      
      <!-- Title -->
      <div class=""invitation-title mb-8"">
        <div class=""text-6xl md:text-7xl mb-4"">💌</div>
        <p class=""text-xl md:text-2xl text-gray-600 font-light tracking-wide"">Trân trọng kính mời</p>
      </div>

      <!-- Greeting -->
      <div class=""invitation-greeting mb-12"">
        <h2 class=""text-4xl md:text-6xl font-bold text-pink-500 mb-6"" style=""font-family: 'Dancing Script', cursive;"">
          <strong>{{{{GUEST_NAME}}}}</strong>
        </h2>
      </div>

      <div class=""divider-ornament"">
        <div class=""ornament-icon"">✨</div>
      </div>

      <!-- Message -->
      <div class=""invitation-message mb-16"">
        <p class=""text-xl md:text-2xl text-gray-700 leading-relaxed max-w-2xl mx-auto"">
          Đến dự tiệc chung vui cùng gia đình chúng tôi<br />
          <span class=""text-pink-500 font-semibold"">trong ngày trọng đại của đời mình</span>
        </p>
      </div>

      <!-- Event Details -->
      <div class=""event-details mb-12"">
        <div class=""mb-8"">
          <div class=""text-5xl md:text-6xl mb-6""></div>
          <div class=""date-badge text-xl md:text-3xl mb-6"">
            Thứ Bảy, 12 tháng 10 năm 2025
          </div>
        </div>

        <div class=""flex flex-wrap justify-center gap-4 md:gap-6 mb-8"">
          <div class=""time-badge text-lg md:text-xl"">
            <span>🕐</span>
            <span class=""font-semibold text-gray-700"">18:00 giờ</span>
          </div>
        </div>
      </div>

      <div class=""divider-ornament"">
        <div class=""ornament-icon"">🌸</div>
      </div>

      <!-- Location -->
      <div class=""location-details mt-12"">
        <div class=""location-card max-w-xl mx-auto"">
          <h3 class=""text-2xl md:text-3xl font-bold text-pink-600 mb-4"">
            Nhà hàng Tiệc Cưới Hoa Mai
          </h3>
          <p class=""text-lg md:text-xl text-gray-700 mb-3"">
            📍 123 Đường Hoa Mai, Quận 10, TP.HCM
          </p>
          <a 
            href=""https://maps.google.com"" 
            target=""_blank""
            class=""inline-block mt-4 bg-gradient-to-r from-pink-400 to-pink-600 text-white font-semibold px-8 py-3 rounded-full hover:scale-105 transition-all duration-300 shadow-lg""
          >
            🗺️ Xem bản đồ
          </a>
        </div>
      </div>

      <!-- Timeline -->
      <div class=""mt-20"">
        <h3 class=""text-3xl md:text-4xl font-bold text-pink-600 mb-12"">Lịch trình sự kiện</h3>
        <div class=""grid md:grid-cols-3 gap-6 md:gap-8"">
          
          <div class=""location-card text-center opacity-0"" style=""animation: fadeInUp 1s ease-out 1.2s forwards;"">
            <div class=""text-4xl md:text-5xl mb-4"">🍸</div>
            <div class=""time-badge mb-4 mx-auto"">17:30</div>
            <h4 class=""text-xl font-bold text-pink-500 mb-2"">Đón khách</h4>
            <p class=""text-gray-600"">Tiệc chào đón & cocktail</p>
          </div>

          <div class=""location-card text-center opacity-0"" style=""animation: fadeInUp 1s ease-out 1.4s forwards;"">
            <div class=""text-4xl md:text-5xl mb-4"">💒</div>
            <div class=""time-badge mb-4 mx-auto"">18:00</div>
            <h4 class=""text-xl font-bold text-pink-500 mb-2"">Lễ thành hôn</h4>
            <p class=""text-gray-600"">Nghi lễ cưới truyền thống</p>
          </div>

          <div class=""location-card text-center opacity-0"" style=""animation: fadeInUp 1s ease-out 1.6s forwards;"">
            <div class=""text-4xl md:text-5xl mb-4"">🎊</div>
            <div class=""time-badge mb-4 mx-auto"">19:00</div>
            <h4 class=""text-xl font-bold text-pink-500 mb-2"">Tiệc cưới</h4>
            <p class=""text-gray-600"">Tiệc tối & giải trí</p>
          </div>

        </div>
      </div>

      <!-- Dress Code -->
      <div class=""mt-16 opacity-0"" style=""animation: fadeInUp 1s ease-out 1.8s forwards;"">
        <div class=""divider-ornament"">
          <div class=""ornament-icon"">👗</div>
        </div>
        <h3 class=""text-2xl md:text-3xl font-bold text-pink-600 mb-6"">Trang phục</h3>
        <div class=""flex flex-wrap justify-center gap-4"">
          <span class=""bg-white px-6 py-3 rounded-full shadow-md text-gray-700 font-semibold border-2 border-pink-200"">
            ✨ Trang trọng
          </span>
          <span class=""bg-white px-6 py-3 rounded-full shadow-md text-gray-700 font-semibold border-2 border-pink-200"">
            💕 Tông màu hồng pastel
          </span>
          <span class=""bg-white px-6 py-3 rounded-full shadow-md text-gray-700 font-semibold border-2 border-pink-200"">
            👔 Vest/Áo dài
          </span>
        </div>
      </div>

    </div>
  </section>

  <!-- Countdown Section -->
  <section class=""py-20 px-4"">
    <div class=""max-w-4xl mx-auto text-center"">
      <h2 class=""section-header text-4xl md:text-5xl font-bold text-pink-600 mb-12"">Đếm ngược đến ngày trọng đại</h2>
      <div id=""countdown"" class=""flex justify-center gap-4 md:gap-8 flex-wrap""></div>
    </div>
  </section>

  <script>
    const countdownEl = document.getElementById(""countdown"");
    const weddingDate = new Date(""2025-12-12T18:00:00"").getTime();
    
    function updateCountdown() {{
      const now = new Date().getTime();
      const distance = weddingDate - now;
      
      const days = Math.floor(distance / (1000 * 60 * 60 * 24));
      const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      const seconds = Math.floor((distance % (1000 * 60)) / 1000);
      
      countdownEl.innerHTML = `
        <div class=""countdown-item"">
          <div class=""text-4xl md:text-6xl font-bold text-pink-600"">${{days}}</div>
          <div class=""text-sm md:text-base text-gray-600 mt-3 font-semibold"">Ngày</div>
        </div>
        <div class=""countdown-item"">
          <div class=""text-4xl md:text-6xl font-bold text-pink-600"">${{hours}}</div>
          <div class=""text-sm md:text-base text-gray-600 mt-3 font-semibold"">Giờ</div>
        </div>
        <div class=""countdown-item"">
          <div class=""text-4xl md:text-6xl font-bold text-pink-600"">${{minutes}}</div>
          <div class=""text-sm md:text-base text-gray-600 mt-3 font-semibold"">Phút</div>
        </div>
        <div class=""countdown-item"">
          <div class=""text-4xl md:text-6xl font-bold text-pink-600"">${{seconds}}</div>
          <div class=""text-sm md:text-base text-gray-600 mt-3 font-semibold"">Giây</div>
        </div>
      `;
    }}
    
    updateCountdown();
    setInterval(updateCountdown, 1000);
  </script>

  <!-- Love Story Timeline -->
  <section class=""py-20 px-4 bg-white/50"">
    <div class=""max-w-5xl mx-auto"">
      <h2 class=""section-header text-4xl md:text-5xl font-bold text-pink-600 text-center mb-16"">Câu chuyện tình yêu</h2>
      
      <div class=""space-y-16"">
        <div class=""timeline-item flex flex-col md:flex-row gap-8 items-center"" style=""animation-delay: 0.2s"">
          <div class=""w-full md:w-1/2"">
            <div class=""gallery-item h-72 md:h-80"">
              <img src=""https://images.unsplash.com/photo-1522673607200-164d1b6ce486?w=800"" alt=""First meet"" />
            </div>
          </div>
          <div class=""w-full md:w-1/2 bg-white/90 p-10 rounded-3xl shadow-xl"">
            <div class=""text-5xl mb-4"">💫</div>
            <h3 class=""text-3xl font-bold text-pink-500 mb-4"">Lần đầu gặp gỡ</h3>
            <p class=""text-gray-600 leading-relaxed text-lg"">
              Đó là một ngày thu đầy nắng vàng. Ánh mắt đầu tiên giữa phố đông đã khiến hai trái tim chúng tôi rung động. Một cuộc gặp gỡ tình cờ đã trở thành khởi đầu cho một chuyện tình đẹp không ngờ.
            </p>
          </div>
        </div>

        <div class=""timeline-item flex flex-col md:flex-row-reverse gap-8 items-center"" style=""animation-delay: 0.4s"">
          <div class=""w-full md:w-1/2"">
            <div class=""gallery-item h-72 md:h-80"">
              <img src=""https://images.unsplash.com/photo-1511285560929-80b456fea0bc?w=800"" alt=""First date"" />
            </div>
          </div>
          <div class=""w-full md:w-1/2 bg-white/90 p-10 rounded-3xl shadow-xl"">
            <div class=""text-5xl mb-4"">☕</div>
            <h3 class=""text-3xl font-bold text-pink-500 mb-4"">Buổi hẹn đầu tiên</h3>
            <p class=""text-gray-600 leading-relaxed text-lg"">
              Quán cà phê nhỏ góc phố cũ, nơi chúng tôi dành cả buổi chiều kể về những ước mơ và kỷ niệm. Từ đó, mỗi ngày đều có thêm một lý do để yêu nhau nhiều hơn chút nữa.
            </p>
          </div>
        </div>

        <div class=""timeline-item flex flex-col md:flex-row gap-8 items-center"" style=""animation-delay: 0.6s"">
          <div class=""w-full md:w-1/2"">
            <div class=""gallery-item h-72 md:h-80"">
              <img src=""https://images.unsplash.com/photo-1519741497674-611481863552?w=800"" alt=""Proposal"" />
            </div>
          </div>
          <div class=""w-full md:w-1/2 bg-white/90 p-10 rounded-3xl shadow-xl"">
            <div class=""text-5xl mb-4"">💍</div>
            <h3 class=""text-3xl font-bold text-pink-500 mb-4"">Lời cầu hôn</h3>
            <p class=""text-gray-600 leading-relaxed text-lg"">
              Dưới bầu trời đêm đầy sao, anh đã quỳ xuống và hỏi em câu hỏi quan trọng nhất đời anh. Và em đã gật đầu với đôi mắt hạnh phúc. Đây là khoảnh khắc đẹp nhất của chúng tôi.
            </p>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- Photo Gallery -->
  <!-- Wedding Photo Gallery -->
<section class=""gallery-section py-20 px-4"">
  <div class=""max-w-6xl mx-auto text-center"">
    <h2 class=""text-4xl md:text-5xl font-bold text-pink-600 mb-4"">Album ảnh cưới</h2>
    <p class=""text-gray-600 mb-12 text-lg"">Những khoảnh khắc đáng nhớ nhất của chúng tôi</p>

    <div class=""gallery-grid grid grid-cols-2 md:grid-cols-4 gap-4 md:gap-6"">
      <!-- Repeat -->
      <template id=""gallery-template"">
        <div class=""gallery-item h-64 md:h-72"">
          <img src="""" alt=""Wedding Photo"" loading=""lazy"" />
          <div class=""gallery-overlay"">📸 Xem ảnh</div>
        </div>
      </template>
    </div>
  </div>
</section>

<!-- Modal Viewer -->
<div id=""albumModal"" class=""album-modal"">
  <div class=""album-content"">
    <button class=""album-close"" title=""Đóng (ESC)"">&times;</button>
    <button class=""album-nav prev"" title=""Trước"">&#10094;</button>
    <img id=""albumSlide"" class=""album-slide"" src="""" alt=""Wedding photo"" />
    <button class=""album-nav next"" title=""Sau"">&#10095;</button>
    <div id=""albumCounter"" class=""album-counter""></div>
  </div>
</div>


  <script>
const albumImages = [
  'https://images.unsplash.com/photo-1465495976277-4387d4b0b4c6?w=1400',
  'https://images.unsplash.com/photo-1522673607200-164d1b6ce486?w=1400',
  'https://images.unsplash.com/photo-1460978812857-470ed1c77af0?w=1400',
  'https://images.unsplash.com/photo-1519741497674-611481863552?w=1400',
  'https://images.unsplash.com/photo-1511285560929-80b456fea0bc?w=1400',
  'https://images.unsplash.com/photo-1520854221256-17451cc331bf?w=1400',
  'https://images.unsplash.com/photo-1583939003579-730e3918a45a?w=1400',
  'https://images.unsplash.com/photo-1583939003579-730e3918a45a?w=1400'
];

const modal = document.getElementById('albumModal');
const slideImg = document.getElementById('albumSlide');
const counter = document.getElementById('albumCounter');
let current = 0;

// Render gallery items dynamically
const grid = document.querySelector('.gallery-grid');
const template = document.getElementById('gallery-template');
albumImages.forEach((src, i) => {{
  const clone = template.content.cloneNode(true);
  const img = clone.querySelector('img');
  img.src = src;
  clone.querySelector('.gallery-item').onclick = () => openAlbum(i);
  grid.appendChild(clone);
}});

function openAlbum(index) {{
  current = index;
  showSlide();
  modal.classList.add('active');
  document.body.style.overflow = 'hidden';
}}

function closeAlbum() {{
  modal.classList.remove('active');
  document.body.style.overflow = '';
}}

function showSlide() {{
  slideImg.src = albumImages[current];
  counter.textContent = `${{current + 1}} / ${{albumImages.length}}`;
}}

function changeSlide(n) {{
  current = (current + n + albumImages.length) % albumImages.length;
  showSlide();
}}

// Controls
document.querySelector('.album-close').onclick = closeAlbum;
document.querySelector('.album-nav.prev').onclick = () => changeSlide(-1);
document.querySelector('.album-nav.next').onclick = () => changeSlide(1);
modal.addEventListener('click', e => e.target === modal && closeAlbum());
document.addEventListener('keydown', e => {{
  if (!modal.classList.contains('active')) return;
  if (e.key === 'Escape') closeAlbum();
  if (e.key === 'ArrowRight') changeSlide(1);
  if (e.key === 'ArrowLeft') changeSlide(-1);
}});
</script>


  <!-- Wishes Section -->
  <section class=""py-20 px-4 bg-white/50"">
    <div class=""max-w-2xl mx-auto"">
      <h2 class=""section-header text-4xl md:text-5xl font-bold text-pink-600 text-center mb-6"">Gửi lời chúc</h2>
      <p class=""text-center text-gray-600 mb-12 text-lg"">Những lời chúc của bạn sẽ là món quà ý nghĩa nhất dành cho chúng tôi</p>
      
      <form id=""wishForm"" class=""invitation-card p-8 md:p-10"">
        <div class=""mb-6"">
          <label class=""block text-gray-700 font-semibold mb-3 text-lg"">Tên của bạn</label>
          <input 
            type=""text"" 
            placeholder=""Nhập tên của bạn..."" 
            class=""w-full px-6 py-4 rounded-xl bg-white/90 text-gray-800 placeholder-gray-400 text-lg""
            required
          />
        </div>
        <div class=""mb-8"">
          <label class=""block text-gray-700 font-semibold mb-3 text-lg"">Lời chúc</label>
          <textarea 
            placeholder=""Gửi lời chúc tốt đẹp nhất đến đôi uyên ương..."" 
            rows=""5""
            class=""w-full px-6 py-4 rounded-xl bg-white/90 text-gray-800 placeholder-gray-400 resize-none text-lg""
            required
          ></textarea>
        </div>
        <button 
          type=""submit"" 
          class=""w-full bg-gradient-to-r from-pink-400 to-pink-600 text-white font-bold py-5 rounded-xl text-lg hover:shadow-2xl transition-all duration-300 hover:scale-[1.02]""
        >
          Gửi lời chúc 💌
        </button>
      </form>
    </div>
  </section>

  <script>
  const wishForm = document.getElementById('wishForm');
  wishForm.addEventListener('submit', async (e) => {{
    e.preventDefault();

    const name = wishForm.querySelector('input').value.trim();
    const message = wishForm.querySelector('textarea').value.trim();
    const btn = wishForm.querySelector('button');
    const originalText = btn.innerHTML;

    if (!name || !message) return;

    // Gửi yêu cầu lên server
    try {{
      const response = await fetch('/api/wedding', {{
        method: 'POST',
        headers: {{ 'Content-Type': 'application/json' }},
        body: JSON.stringify({{ name, message }})
      }});

      if (!response.ok) throw new Error('Send failed');

      // Hiệu ứng tim bay 💗
      for (let i = 0; i < 20; i++) {{
        setTimeout(() => {{
          const heart = document.createElement('div');
          heart.className = 'heart-float';
          heart.textContent = ['💗', '💕', '💖', '💝', '❤️'][Math.floor(Math.random() * 5)];
          heart.style.left = (Math.random() * window.innerWidth) + 'px';
          heart.style.top = (window.innerHeight - 100) + 'px';
          document.body.appendChild(heart);
          setTimeout(() => heart.remove(), 3500);
        }}, i * 80);
      }}

      // Thông báo thành công
      btn.innerHTML = '✓ Đã gửi! Cảm ơn bạn ❤️';
      btn.style.background = 'linear-gradient(135deg, #10b981, #059669)';
      btn.disabled = true;
      wishForm.reset();

      setTimeout(() => {{
        btn.innerHTML = originalText;
        btn.style.background = '';
        btn.disabled = false;
      }}, 3500);

    }} catch (err) {{
      alert('❌ Gửi thất bại, vui lòng thử lại.');
      console.error(err);
    }}
  }});
</script>

  <!-- RSVP Section -->
  <section class=""py-20 px-4"">
    <div class=""max-w-3xl mx-auto text-center"">
      <h2 class=""section-header text-4xl md:text-5xl font-bold text-pink-600 mb-6"">Xác nhận tham dự</h2>
      <p class=""text-gray-600 mb-12 text-lg"">Vui lòng cho chúng tôi biết bạn có thể tham dự không nhé!</p>
      
      <div class=""flex flex-col sm:flex-row gap-6 justify-center px-4"">
        <button 
          class=""rsvp-btn bg-gradient-to-r from-green-400 to-green-500 text-white font-bold px-12 py-6 rounded-full text-lg shadow-xl""
          onclick=""handleRSVP(true)""
        >
          <span class=""relative z-10"">🌸 Tôi sẽ tham dự 🌸</span>
        </button>
        <button 
          class=""rsvp-btn bg-gradient-to-r from-red-300 to-gray-600 text-white font-bold px-12 py-6 rounded-full text-lg shadow-xl""
          onclick=""handleRSVP(false)""
        >
          <span class=""relative z-10"">💐 Xin lỗi, tôi không thể đến dự được 🎀</span>
        </button>
      </div>

      <div class=""mt-16 invitation-card p-8 md:p-10"">
        <h3 class=""text-2xl font-bold text-pink-600 mb-6"">Thông tin liên hệ</h3>
        <div class=""grid md:grid-cols-2 gap-6 text-left"">
          <div class=""bg-white/80 p-6 rounded-xl"">
            <div class=""text-4xl mb-3"">👰</div>
            <h4 class=""font-bold text-lg text-pink-500 mb-2"">Ngọc Quyên</h4>
            <p class=""text-gray-600 mb-2"">📱 0901 234 567</p>
            <p class=""text-gray-600"">💌 ngocquyen@email.com</p>
          </div>
          <div class=""bg-white/80 p-6 rounded-xl"">
            <div class=""text-4xl mb-3"">🤵</div>
            <h4 class=""font-bold text-lg text-pink-500 mb-2"">Hữu Châu</h4>
            <p class=""text-gray-600 mb-2"">📱 0912 345 678</p>
            <p class=""text-gray-600"">💌 huuchau@email.com</p>
          </div>
        </div>
      </div>
    </div>
  </section>

  <script>
    function handleRSVP(attending) {{
      const message = attending 
        ? '🎊 Cảm ơn bạn! Chúng tôi rất mong được gặp bạn!' 
        : '💝 Cảm ơn vì đã thông báo. Hy vọng có dịp gặp lại!';
      
      for (let i = 0; i < 25; i++) {{
        setTimeout(() => {{
          const heart = document.createElement('div');
          heart.className = 'heart-float';
          heart.textContent = attending ? '🎉' : '💝';
          heart.style.left = (Math.random() * window.innerWidth) + 'px';
          heart.style.top = (window.innerHeight - 100) + 'px';
          document.body.appendChild(heart);
          setTimeout(() => heart.remove(), 3500);
        }}, i * 60);
      }}
      
      const modal = document.createElement('div');
      modal.className = 'fixed inset-0 flex items-center justify-center z-50 px-4';
      modal.style.background = 'rgba(0,0,0,0.7)';
      modal.style.animation = 'fadeIn 0.3s ease';
      modal.innerHTML = `
        <div class=""bg-white rounded-3xl p-10 max-w-md text-center shadow-2xl"" style=""animation: slideIn 0.4s ease;"">
          <div class=""text-6xl mb-4"">${{attending ? '🎊' : '💝'}}</div>
          <p class=""text-2xl font-bold text-gray-800 mb-2"">${{attending ? 'Tuyệt vời!' : 'Cảm ơn <br>{{{{GUEST_NAME}}}} '}}</p>
          <p class=""text-gray-600 text-lg mb-6"">${{message}}</p>
          <button onclick=""this.closest('div').parentElement.remove()"" 
            class=""bg-gradient-to-r from-pink-400 to-pink-600 text-white font-bold px-8 py-3 rounded-full hover:scale-105 transition-transform"">
            Đóng
          </button>
        </div>
      `;
      document.body.appendChild(modal);
      setTimeout(() => modal.remove(), 5000);
    }}
  </script>

  <!-- Footer -->
  <footer class=""py-16 text-center bg-gradient-to-b from-transparent to-pink-50"">
    <div class=""decoration-line max-w-md mx-auto mb-8""></div>
    <div class=""text-7xl mb-6"">💑</div>
    <p class=""text-xl md:text-2xl text-gray-700 italic mb-4 px-4"">
      Cảm ơn bạn đã là một phần trong ngày hạnh phúc của chúng tôi
    </p>
    <p class=""text-pink-500 font-bold text-3xl md:text-4xl mb-2"" style=""font-family: 'Dancing Script', cursive;"">
      Ngọc Quyên & Hữu Châu
    </p>
    <p class=""text-gray-500 mt-6 text-base"">
      12.10.2025 • Forever & Always 💕
    </p>
    <div class=""decoration-line max-w-md mx-auto mt-8""></div>
  </footer>

  <!-- Music Control Script -->
  <script>
    const music = document.getElementById('bgMusic');
    const musicControl = document.getElementById('musicControl');
    const musicIcon = document.getElementById('musicIcon');
    let isPlaying = false;

    document.body.addEventListener('click', () => {{
      if (!isPlaying) {{
        music.play().then(() => {{
          isPlaying = true;
          musicControl.classList.remove('paused');
          updateMusicIcon();
        }}).catch(() => {{}});
      }}
    }}, {{ once: true }});

    musicControl.addEventListener('click', (e) => {{
      e.stopPropagation();
      if (isPlaying) {{
        music.pause();
        isPlaying = false;
        musicControl.classList.add('paused');
      }} else {{
        music.play();
        isPlaying = true;
        musicControl.classList.remove('paused');
      }}
      updateMusicIcon();
    }});

    function updateMusicIcon() {{
      if (isPlaying) {{
        musicIcon.innerHTML = '<path d=""M12 3v10.55c-.59-.34-1.27-.55-2-.55-2.21 0-4 1.79-4 4s1.79 4 4 4 4-1.79 4-4V7h4V3h-6z""/>';
      }} else {{
        musicIcon.innerHTML = '<path d=""M4.27 3L3 4.27l9 9v.28c-.59-.34-1.27-.55-2-.55-2.21 0-4 1.79-4 4s1.79 4 4 4 4-1.79 4-4v-1.73L19.73 21 21 19.73 4.27 3zM14 7h4V3h-6v5.18l2 2z""/>';
      }}
    }}
  </script>

  <!-- Loading Script -->
  <script>
    window.addEventListener('load', () => {{
      setTimeout(() => {{
        document.getElementById('loadingOverlay').classList.add('hidden');
      }}, 1000);
    }});
  </script>

</body>
</html>";
    }
}
