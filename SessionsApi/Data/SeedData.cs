using SessionsApi.Models;

namespace SessionsApi.Data;

public static class SeedData
{
    public static void Initialize(ConferenceDbContext db)
    {
        if (db.Sessions.Any()) return;

        db.Sessions.AddRange(
            new Session
            {
                Title = "Bienvenida OpensouthCode 2026 / Welcome to OpenSouthCode 2026",
                Description = "Bienvenida OpensouthCode 2026 / Welcome to OpenSouthCode 2026",
                SpeakerName = "",
                SpeakerBio = "",
                Room = "Sala Fuengirola",
                Time = "09:15",
                Tags = ["Welcome"],
                MaxAttendees = 300
            },
            new Session
            {
                Title = "Migrando la criptografía de Internet. Retos y oportunidades",
                Description = "Un breve paseo por el mundo de la criptografía postcuántica. En esta charla se abordarán los principios fundamentales de la computación cuántica y los riesgos que plantea para la ciberseguridad, en particular en la criptografía de clave pública.",
                SpeakerName = "Osiris García Parras, Isaac",
                SpeakerBio = "Un breve paseo por el mundo de la criptografía postcuántica",
                Room = "Sala Benalmádena 002",
                Time = "09:30",
                Tags = ["Criptografía", "Postcuántica", "Seguridad"],
                MaxAttendees = 120
            },
            new Session
            {
                Title = "Las claves de la seguridad en Ubuntu",
                Description = "Una mirada desde el interior del Security Team. En un panorama de ciberamenazas cada vez más complejas, la gestión integral de la seguridad de un sistema operativo requiere una estrategia proactiva y multicapa.",
                SpeakerName = "Federico Quattrin",
                SpeakerBio = "Una mirada desde el interior del Security Team",
                Room = "Sala Canillas 013",
                Time = "09:30",
                Tags = ["Ubuntu", "Seguridad", "Linux"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Running and Fine-Tuning a Large Language Model on Your Laptop",
                Description = "Understanding and experimenting with LLMs through a manageable local model. Running a local LLM enables direct inspection of its architecture, weights, and output logits.",
                SpeakerName = "antfperez",
                SpeakerBio = "Understanding and experimenting with LLMs through a manageable local model",
                Room = "Sala Fuengirola",
                Time = "09:30",
                Tags = ["LLM", "AI", "Machine Learning"],
                MaxAttendees = 200
            },
            new Session
            {
                Title = "Growing the Linux App Ecosystem with RISC-V and RVA23 Platforms",
                Description = "RISC-V & RVA23. The Linux application ecosystem continues to expand as new hardware platforms and distribution channels bring Linux to more developers worldwide. One of the most promising developments is RISC-V.",
                SpeakerName = "Yuning Liang",
                SpeakerBio = "RISC-V & RVA23",
                Room = "Sala Benamocarra 23",
                Time = "10:30",
                Tags = ["RISC-V", "Linux", "Hardware"],
                MaxAttendees = 80
            },
            new Session
            {
                Title = "¿Discord? ¿Slack? Entra en la Matrix",
                Description = "Iniciación a Matrix chat. Matrix es un protocolo abierto, descentralizado y federado para una comunicación segura y soberana. Exploraremos por qué este estándar está cambiando las reglas del juego.",
                SpeakerName = "Alejandro Ríos",
                SpeakerBio = "Iniciación a Matrix chat",
                Room = "Sala Fuengirola",
                Time = "10:30",
                Tags = ["Matrix", "Comunicación", "Open Source"],
                MaxAttendees = 150
            },
            new Session
            {
                Title = "Stop wasting nodes! A surgical way to make overcommit on Kubernetes",
                Description = "Kubernetes overcommit operator. Our challenge was that Kubernetes nodes appeared fully allocated while much of their capacity remained unused due to oversized resource requests. By introducing dynamic overcommit we solved this.",
                SpeakerName = "Enrique Andrés Villar, luisreciomelero",
                SpeakerBio = "Kubernetes overcommit operator",
                Room = "Sala Canillas 013",
                Time = "10:30",
                Tags = ["Kubernetes", "Cloud Native", "DevOps"],
                MaxAttendees = 120
            },
            new Session
            {
                Title = "Decoding design: why open source can't thrive without open design",
                Description = "Open source design. In this talk, we will explore how to dismantle the 'us vs them' mentality between engineers and designers and build experiences that are as empowering to use as they are to code.",
                SpeakerName = "Miguel Divo",
                SpeakerBio = "Open source design",
                Room = "Sala Benalmádena 002",
                Time = "10:30",
                Tags = ["Design", "UX", "Open Source"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Supercharging Grafana with Community Plugins",
                Description = "Grafana is powerful on its own. However, its true potential lies in its vibrant community of plugin developers. We'll explore how community plugins extend Grafana's core functionality.",
                SpeakerName = "eyeveebee",
                SpeakerBio = "",
                Room = "Sala Benalmádena 002",
                Time = "11:30",
                Tags = ["Grafana", "Observabilidad", "Plugins"],
                MaxAttendees = 120
            },
            new Session
            {
                Title = "Plataforma de Domotica Open Source",
                Description = "Domotic AI. Demostración práctica sobre la instalación, configuración y uso de una avanzada plataforma de domótica diseñada para la gestión integral y el monitoreo de alertas en entornos residenciales.",
                SpeakerName = "Adrian Duardo Yanes, jduardo",
                SpeakerBio = "Domotic AI",
                Room = "Sala Canillas 013",
                Time = "11:30",
                Tags = ["Domótica", "IoT", "Open Source"],
                MaxAttendees = 80
            },
            new Session
            {
                Title = "Docker no es un Sandbox: defensa en profundidad para arquitecturas de contenedores",
                Description = "Análisis de las limitaciones del aislamiento por defecto y estrategias de fortificación desde el host hasta la red. Los contenedores están muy lejos de ser esas robustas cajas de metal herméticas que su nombre nos sugiere.",
                SpeakerName = "Alejandro Galán Rita",
                SpeakerBio = "Análisis de las limitaciones del aislamiento por defecto",
                Room = "Sala Fuengirola",
                Time = "11:30",
                Tags = ["Docker", "Seguridad", "Contenedores"],
                MaxAttendees = 180
            },
            new Session
            {
                Title = "Newelle - Your Ultimate Virtual Assistant with Sovereign AI",
                Description = "Virtual Assistant for the Modern Linux Desktop with Local LLM. Newelle is an open-source, AI-powered virtual assistant that runs locally on Linux and seamlessly integrates into the GNOME desktop ecosystem.",
                SpeakerName = "Khairul Aizat Kamarudzzzaman",
                SpeakerBio = "Virtual Assistant for the Modern Linux Desktop with Local LLM",
                Room = "Sala Benamocarra 23",
                Time = "11:30",
                Tags = ["AI", "Linux", "GNOME", "Asistente"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Docs-as-code: past, present, and future",
                Description = "As experienced at SUSE. We'll dip into its evolution, moving from the foundations of UNIX towards an AI-assisted present and future, with live demonstrations using UNIX V7 on a PDP-11/70.",
                SpeakerName = "John Krug",
                SpeakerBio = "As experienced at SUSE",
                Room = "Sala Benalmádena 002",
                Time = "12:30",
                Tags = ["Documentación", "Docs-as-Code", "SUSE"],
                MaxAttendees = 90
            },
            new Session
            {
                Title = "De Kafka a Iceberg: construyendo un pipeline de datos moderno con SparkSQL y Airflow",
                Description = "¿Cómo transformas un flujo continuo de eventos en datos analíticos de calidad, con SQL como lenguaje principal y sin infraestructura ad-hoc? Un arquitecto y un data engineer cuentan cómo lo hicieron.",
                SpeakerName = "Juanlu Hidalgo, Ignacio",
                SpeakerBio = "",
                Room = "Sala Fuengirola",
                Time = "12:30",
                Tags = ["Kafka", "Iceberg", "SparkSQL", "Airflow", "Datos"],
                MaxAttendees = 120
            },
            new Session
            {
                Title = "OpenPrinting - We continue to make printing just work!",
                Description = "Stay tuned ... Due to the fact that I got laid off from Canonical last year things are changing at OpenPrinting to assure that we can continue our work in the future.",
                SpeakerName = "Till Kamppeter",
                SpeakerBio = "Stay tuned ...",
                Room = "Sala Canillas 013",
                Time = "12:30",
                Tags = ["Impresión", "OpenPrinting", "Linux"],
                MaxAttendees = 70
            },
            new Session
            {
                Title = "Programando GNU/Hurd con Rust",
                Description = "Desarrollo de translators en Rust. El sistema operativo GNU/Hurd incluye el uso de translators: programas asociados a un fichero que se ejecutan cuando estos son accedidos. Actualmente se implementan desde librerías de C.",
                SpeakerName = "Almudena Garcia",
                SpeakerBio = "Desarrollo de translators en Rust",
                Room = "Sala Benamocarra 23",
                Time = "12:30",
                Tags = ["GNU", "Hurd", "Rust", "Sistemas Operativos"],
                MaxAttendees = 80
            },
            new Session
            {
                Title = "Aspire: Orquestación, DevEx y observabilidad con IA integrada",
                Description = "Domina los microservicios: integrando agentes de IA, arquitecturas políglotas y observabilidad total en una plataforma abierta. Descubriremos Aspire, la plataforma que se ha consolidado como el pegamento universal para cualquier arquitectura distribuida.",
                SpeakerName = "Javier Torralbo",
                SpeakerBio = "Domina los microservicios: integrando agentes de IA",
                Room = "Sala Benalmádena 002",
                Time = "13:30",
                Tags = ["Aspire", ".NET", "Microservicios", "IA"],
                MaxAttendees = 150
            },
            new Session
            {
                Title = "CODA: A new contribution model for open source",
                Description = "How an aggregated task tracker and mentorship solve the contributor's dilemma. Open source needs contributors, but traditional onboarding is broken. We need a paradigm shift.",
                SpeakerName = "Graham Morrison",
                SpeakerBio = "How an aggregated task tracker and mentorship solve the contributor's dilemma",
                Room = "Sala Canillas 013",
                Time = "13:30",
                Tags = ["Open Source", "Comunidad", "Contribución"],
                MaxAttendees = 90
            },
            new Session
            {
                Title = "¿Quién teme al hacker feroz?",
                Description = "Nociones sobre ciberseguridad en clave de cuento. En los tiempos que corren, nuestras vidas están ligadas a activos digitales como nuestros datos personales, nuestra privacidad y nuestra seguridad financiera.",
                SpeakerName = "Mar Bartolomé",
                SpeakerBio = "Nociones sobre ciberseguridad en clave de cuento",
                Room = "Sala Benamocarra 23",
                Time = "13:30",
                Tags = ["Ciberseguridad", "Divulgación", "Privacidad"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Mesa redonda: Software libre y universidad",
                Description = "Un diálogo entre universidad y comunidad. Las universidades y las comunidades del software libre comparten el principio del libre intercambio del conocimiento. Escarlata González entrevista a Manuel Enciso.",
                SpeakerName = "Manuel Enciso, Escarlata",
                SpeakerBio = "Un diálogo entre universidad y comunidad",
                Room = "Sala Fuengirola",
                Time = "13:30",
                Tags = ["Software Libre", "Universidad", "Educación"],
                MaxAttendees = 130
            },
            new Session
            {
                Title = "Networking",
                Description = "Tendremos 2h para hacer networking con un refrigerio en el Patio del tiempo para los asistentes al evento.",
                SpeakerName = "",
                SpeakerBio = "",
                Room = "Patio del tiempo",
                Time = "14:15",
                Tags = ["Networking", "Social"],
                MaxAttendees = 300
            },
            new Session
            {
                Title = "Defending Router Freedom in the EU",
                Description = "Latest developments. Router Freedom is a cornerstone of digital self-determination: users should be free to choose and use their own router or modem instead of being forced to rely on provider-supplied equipment.",
                SpeakerName = "Dario Presutti",
                SpeakerBio = "Latest developments",
                Room = "Sala Fuengirola",
                Time = "15:30",
                Tags = ["Router Freedom", "FSFE", "Privacidad"],
                MaxAttendees = 120
            },
            new Session
            {
                Title = "OpenSouthRetro",
                Description = "La combinación entre la retroinformática y el código abierto en una exposición viva donde rendimos homenaje a los juegos de 8, 16 y 32 bits con los que crecimos.",
                SpeakerName = "Jorge Hidalgo, Juan A. Ortega, Eramis",
                SpeakerBio = "",
                Room = "Sala Benamargosa 21",
                Time = "15:30",
                Tags = ["Retro", "Videojuegos", "Open Source"],
                MaxAttendees = 200
            },
            new Session
            {
                Title = "Descubre e intercepta un Ciberataque",
                Description = "Cómo usar herramientas Open Source para descubrir y bloquear un ataque antes de que sea tarde (Live Demo). Una demostración en vivo que nos lleva por el ciclo completo de un ciberataque.",
                SpeakerName = "Javier González",
                SpeakerBio = "Cómo usar herramientas Open Source para descubrir y bloquear un ataque",
                Room = "Sala Benamocarra 23",
                Time = "15:30",
                Tags = ["Ciberseguridad", "Hacking", "Live Demo"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "CSS as a game engine",
                Description = "Practicing web development the fun way. In this talk, we'll explore how far you can push the web platform using nothing but HTML and CSS, building games with CSS as a Finite State Machine.",
                SpeakerName = "alvaromontoro",
                SpeakerBio = "Practicing web development the fun way",
                Room = "Sala Benalmádena 002",
                Time = "15:30",
                Tags = ["CSS", "HTML", "Web", "Game Development"],
                MaxAttendees = 150
            },
            new Session
            {
                Title = "WordPress & MCP: Integración con Clientes de IA para una administración simple",
                Description = "Del 'clic' al 'prompt': Implementación del protocolo MCP para la administración de sitios WordPress. En esta sesión práctica aplicaremos esta tecnología a cualquier sitio WordPress.",
                SpeakerName = "fcjurado",
                SpeakerBio = "Del 'clic' al 'prompt': Implementación del protocolo MCP",
                Room = "Sala Canillas 013",
                Time = "15:30",
                Tags = ["WordPress", "MCP", "IA", "CMS"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Cómo auditar proyectos Open Source y conseguir tu primer CVE",
                Description = "Taller práctico de hacking en vivo: Encuentra, valida y reporta vulnerabilidades reales. Este taller es una sesión de hacking en vivo diseñada para que los asistentes encuentren vulnerabilidades reales en proyectos Open Source activos.",
                SpeakerName = "Javier Juárez Zarruk, Cristian Fernández Conejo, Dario Rivas",
                SpeakerBio = "Taller práctico de hacking en vivo",
                Room = "Sala Frigiliana - 20",
                Time = "15:30",
                Tags = ["Seguridad", "CVE", "Hacking", "Taller"],
                MaxAttendees = 60
            },
            new Session
            {
                Title = "The open source coding revolution",
                Description = "AI has found its killer app: the coding agent. Can open source compete in the global coding arena? In this talk, we will present a full open source stack that provides everything you need for AI-assisted coding.",
                SpeakerName = "Adrian Tineo",
                SpeakerBio = "",
                Room = "Sala Fuengirola",
                Time = "16:30",
                Tags = ["AI", "Coding Agents", "Open Source"],
                MaxAttendees = 200
            },
            new Session
            {
                Title = "Sintonizando tus apps en Flutter",
                Description = "Para aprender sobre state management y backend en este framework crossplatform. Es el momento de empezar a hablar de state y también de backend para tratar y almacenar esos datos con los que operas.",
                SpeakerName = "Asher Guzmán Blanco",
                SpeakerBio = "Aprende sobre state management y backend en Flutter",
                Room = "Sala Benalmádena 002",
                Time = "16:30",
                Tags = ["Flutter", "Dart", "Mobile", "State Management"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Operate your homelab apps using Juju",
                Description = "Juju is adapting the way operation engineers manage their homelab applications. Juju is an operator orchestration engine that provides a streamlined approach for handling deployment, integration, and lifecycle management.",
                SpeakerName = "Erin Conley, Grégory Schiano",
                SpeakerBio = "",
                Room = "Sala Canillas 013",
                Time = "16:30",
                Tags = ["Juju", "Homelab", "DevOps", "Orquestación"],
                MaxAttendees = 80
            },
            new Session
            {
                Title = "Tu máquina, tus modelos, tus reglas: El poder de la IA sin conexión",
                Description = "En este taller práctico, destriparemos el caso real de un negocio que eliminó sus altísimas facturas de procesado montando su propia IA de código abierto.",
                SpeakerName = "Fede",
                SpeakerBio = "",
                Room = "Sala Canillas 013",
                Time = "17:30",
                Tags = ["IA", "Offline", "Open Source", "Taller"],
                MaxAttendees = 80
            },
            new Session
            {
                Title = "El año de [empaquetar tu aplicación Python para] Linux en el escritorio",
                Description = "Empaquetar Python y Rust para Linux es fácil, si sabes cómo. En este taller aprenderás cómo usar técnicas y herramientas modernas de paquetería para distribuir tu aplicación Python en Linux.",
                SpeakerName = "Juan Luis Cano Rodríguez",
                SpeakerBio = "Empaquetar Python y Rust para Linux es fácil, si sabes cómo",
                Room = "Sala Frigiliana - 20",
                Time = "17:30",
                Tags = ["Python", "Linux", "Packaging", "Rust"],
                MaxAttendees = 60
            },
            new Session
            {
                Title = "Java cumple 31 años y repasamos las novedades de Java 26 y 27 (Málaga JUG)",
                Description = "Málaga JUG trae como es ya casi tradición la charla con las novedades de este último año en Java. Ponemos el foco en Java 26 y 27.",
                SpeakerName = "Jorge Hidalgo",
                SpeakerBio = "",
                Room = "Sala Fuengirola",
                Time = "17:30",
                Tags = ["Java", "Málaga JUG", "JVM"],
                MaxAttendees = 130
            },
            new Session
            {
                Title = "AI Agents for Vulnerability Detection in Smart Contracts",
                Description = "This session explores the critical architectural shifts between Web2 and Web3 vulnerabilities. We will dive into agentic open-source tools and practical workflows for securing the decentralized ecosystem.",
                SpeakerName = "A. Rosa Castillo",
                SpeakerBio = "",
                Room = "Sala Benalmádena 002",
                Time = "17:30",
                Tags = ["AI", "Smart Contracts", "Web3", "Seguridad"],
                MaxAttendees = 90
            },
            new Session
            {
                Title = "De la Torre de Babel al Internet de Agentes: el proyecto open-source AGNTCY",
                Description = "Construir sistemas de IA multi-agente hoy se parece demasiado a la Torre de Babel. Descubre AGNTCY, un proyecto open-source de la Linux Foundation que está creando el Internet de los Agentes.",
                SpeakerName = "Alfonso Sandoval Rosas",
                SpeakerBio = "",
                Room = "Sala Benamocarra 23",
                Time = "17:30",
                Tags = ["Agentes", "IA", "AGNTCY", "Linux Foundation"],
                MaxAttendees = 90
            },
            new Session
            {
                Title = "Por qué soy un analfabeto tecnológico pero me importa el Software Libre",
                Description = "Porqué el Software Libre es un must en nuestra sociedades actuales y qué hace la FSFE. Veremos qué es el Software Libre y porque es importante en todos los ámbitos de nuestra sociedad.",
                SpeakerName = "anaghz",
                SpeakerBio = "Porqué el Software Libre es un must en nuestra sociedades actuales",
                Room = "Sala Benamocarra 23",
                Time = "18:30",
                Tags = ["Software Libre", "FSFE", "Sociedad"],
                MaxAttendees = 80
            },
            new Session
            {
                Title = "Malaga-AI Community Session: Career Advice in the Age of AI, a free app for the community",
                Description = "Malaga-AI unveils a new app for the community: Career Advice in the Age of AI. A free tool to analyze your CV or LinkedIn profile and provide personalized career recommendations.",
                SpeakerName = "Adrian Tineo",
                SpeakerBio = "",
                Room = "Sala Fuengirola",
                Time = "18:30",
                Tags = ["AI", "Carrera", "Málaga", "Comunidad"],
                MaxAttendees = 150
            },
            new Session
            {
                Title = "Why most tech communities die (and how to make sure yours doesn't)",
                Description = "Practical lessons from 15 years of building and sustaining communities. Running a tech community requires concrete tactics, knowing about event formats, and learning from people who've already tried.",
                SpeakerName = "Raúl Jiménez Ortega",
                SpeakerBio = "Practical lessons from 15 years of building and sustaining communities",
                Room = "Sala Canillas 013",
                Time = "18:30",
                Tags = ["Comunidad", "Tech", "Eventos"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "The Binary You Ship Is the Binary You Test",
                Description = "Runtime coverage for any binary, no instrumentation required. xcover takes a different approach: eBPF uprobes attach to any compiled binary at runtime, no source changes, no build flags, no instrumentation.",
                SpeakerName = "Massimiliano Giovagnoli",
                SpeakerBio = "Runtime coverage for any binary, no instrumentation required",
                Room = "Sala Benalmádena 002",
                Time = "18:30",
                Tags = ["eBPF", "Testing", "Cobertura", "Binarios"],
                MaxAttendees = 80
            },
            new Session
            {
                Title = "Cena Networking / Dinner Networking",
                Description = "Si eres speaker / sponsor o has donado en la campaña de donación, podrás acceder a la cena networking que realizaremos en el Patio del tiempo.",
                SpeakerName = "",
                SpeakerBio = "",
                Room = "Patio del tiempo",
                Time = "19:15",
                Tags = ["Networking", "Social", "Cena"],
                MaxAttendees = 200
            },
            new Session
            {
                Title = "OpenSouthRetro (Día 2)",
                Description = "Continuación de la exposición sobre retroinformática y código abierto. Homenaje a las plataformas y juegos de 8, 16 y 32 bits.",
                SpeakerName = "Jorge Hidalgo, Juan A. Ortega, Eramis",
                SpeakerBio = "",
                Room = "Sala Benamargosa 21",
                Time = "10:00",
                Tags = ["Retro", "Videojuegos", "Open Source"],
                MaxAttendees = 200
            },
            new Session
            {
                Title = "Too old for this sh*t: MIDI Maze, Atari ST, Raspberry Pico, IA y otras malas decisiones",
                Description = "O cómo perder la dignidad técnica rehaciendo MIDI Maze en 2026. En esta charla os cuento una idea que en mi cabeza sonaba genial: coger MIDI Maze y reconstruirla como una red distribuida sobre TCP/IP.",
                SpeakerName = "Diego Parrilla",
                SpeakerBio = "O cómo perder la dignidad técnica rehaciendo MIDI Maze en 2026",
                Room = "Sala Benalmádena 002",
                Time = "10:00",
                Tags = ["Retro", "MIDI", "Atari", "Raspberry Pi", "IA"],
                MaxAttendees = 120
            },
            new Session
            {
                Title = "SecurAI",
                Description = "Una aplicación inteligente para la detección de ataques en tu red. Se presenta una aplicación que incorpora un IDS que se ejecutará localmente en tiempo real analizando el tráfico de la red con técnicas de IA.",
                SpeakerName = "Álvaro",
                SpeakerBio = "Una aplicación inteligente para la detección de ataques en tu red",
                Room = "Sala Canillas 013",
                Time = "10:00",
                Tags = ["Seguridad", "IA", "IDS", "Red"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "How to Prototype Impactful Products Using AI",
                Description = "Proposals to have a hands on prototyping. From Idea to Impact: AI-Driven Prototyping for the Open Web. Explora cómo usar inteligencia artificial para crear productos que resuelvan problemas reales.",
                SpeakerName = "Amalia Gómez",
                SpeakerBio = "Proposals to have a hands on prototyping",
                Room = "Sala Frigiliana - 20",
                Time = "10:00",
                Tags = ["AI", "Prototyping", "Product", "Taller"],
                MaxAttendees = 60
            },
            new Session
            {
                Title = "Our AI Agents Are Finally In Production — And Now What?",
                Description = "The profound impact of Agentic AIs in businesses is making organizations focus on creating and launching AI agents. We will present the common challenges to build, deploy and run Agentic AI platforms at scale.",
                SpeakerName = "Jorge Hidalgo, José María Gutiérrez Ramírez",
                SpeakerBio = "",
                Room = "Sala Fuengirola",
                Time = "10:00",
                Tags = ["AI", "Agentes", "Producción", "Escalabilidad"],
                MaxAttendees = 180
            },
            new Session
            {
                Title = "OpenSouthKids",
                Description = "OpenSouthKids: Cultura y tecnologías abiertas para todas las edades. Actividades educativas y entretenidas para todas las edades, pensadas para 5-15 años pero abiertas a todos.",
                SpeakerName = "",
                SpeakerBio = "",
                Room = "Sala Málaga",
                Time = "10:00",
                Tags = ["Educación", "Niños", "Tecnología"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Cuando lo 'smart' nos deja a oscuras: fragilidad, dependencias y grandes fallos en la nube",
                Description = "Cómo la nube convirtió tu hogar en un punto único de fallo. Un simple incidente en la nube puede dejar inutilizable una cama inteligente de 2.700 dólares o bloquear accesos a hogares.",
                SpeakerName = "Sebastian Luna",
                SpeakerBio = "Cómo la nube convirtió tu hogar en un punto único de fallo",
                Room = "Sala Benalmádena 002",
                Time = "11:00",
                Tags = ["IoT", "Cloud", "Dependencias", "Fragilidad"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "We Trained a Probability Engine and Accidentally Called It AI",
                Description = "How Next-Token Prediction Became a Product Feature. This talk takes a practical, grassroots view of modern LLMs as they appear in real developer workflows.",
                SpeakerName = "Akarshan Kapoor",
                SpeakerBio = "How Next-Token Prediction Became a Product Feature",
                Room = "Sala Canillas 013",
                Time = "11:00",
                Tags = ["AI", "LLM", "Probabilidad", "Producto"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Introducción a los componentes internos de una base de datos",
                Description = "¿Alguna vez te has planteado cómo se hacen estos monumentos del software? Te llevaré por los caminos y entresijos de un sistema de gestión de base de datos.",
                SpeakerName = "Iván Sánchez Valencia",
                SpeakerBio = "",
                Room = "Sala Fuengirola",
                Time = "11:00",
                Tags = ["Bases de Datos", "Postgres", "MySQL", "Arquitectura"],
                MaxAttendees = 150
            },
            new Session
            {
                Title = "Load testing workshop with k6 OSS",
                Description = "A hands-on introduction to performance and reliability testing. This workshop introduces the fundamentals of performance and load testing using k6 OSS with a simple demo application.",
                SpeakerName = "Pepe Cano",
                SpeakerBio = "A hands-on introduction to performance and reliability testing",
                Room = "Sala Frigiliana - 20",
                Time = "12:00",
                Tags = ["Testing", "k6", "Rendimiento", "Taller"],
                MaxAttendees = 60
            },
            new Session
            {
                Title = "Todo iba bien.... hasta que la IA empezó a inventar",
                Description = "Veremos a través de demos en vivo como construir aplicaciones de IA usando herramientas open source y modelos ejecutándose en local. Desde un chatbot básico hasta sistemas con RAG.",
                SpeakerName = "Patri, Estefanía Ríos",
                SpeakerBio = "",
                Room = "Sala Canillas 013",
                Time = "12:00",
                Tags = ["IA", "RAG", "Open Source", "Chatbot"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Renovate Your Life",
                Description = "How we automated dependency updates for 1,300 Repos (and lived to tell the tale). Picture this: you're managing dependencies across 1,300+ repositories, security vulnerabilities pile up, and this became a full automation adventure.",
                SpeakerName = "Philip Hope, Dimitrios Sotirakis",
                SpeakerBio = "How we automated dependency updates for 1,300 Repos",
                Room = "Sala Fuengirola",
                Time = "12:00",
                Tags = ["Renovate", "Dependencies", "DevOps", "Automatización"],
                MaxAttendees = 130
            },
            new Session
            {
                Title = "Observability and Alerting for your Applications using Open Source Tools",
                Description = "Modern applications are glued together as a single unit where microservices work together. We will explore open source tools for observability and alerting across the stack.",
                SpeakerName = "antoniocm",
                SpeakerBio = "",
                Room = "Sala Benalmádena 002",
                Time = "12:00",
                Tags = ["Observabilidad", "Alerting", "Open Source"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "¿El fin de las contraseñas? Passwordless en Linux con SSSD",
                Description = "La transición hacia entornos sin contraseñas (passwordless) es una realidad imparable, pero su adopción en el escritorio Linux presenta retos técnicos profundos que exploraremos en esta charla.",
                SpeakerName = "Iker Pedrosa",
                SpeakerBio = "",
                Room = "Sala Fuengirola",
                Time = "13:00",
                Tags = ["Passwordless", "SSSD", "Linux", "Autenticación"],
                MaxAttendees = 120
            },
            new Session
            {
                Title = "Your System Isn't Slow, You're Measuring It Wrong",
                Description = "Most performance issues are solved the same way: add more CPU, more memory, or scale out. In this session, we'll explore a practical approach to performance engineering using open-source tools.",
                SpeakerName = "Guillermo Ruiz",
                SpeakerBio = "",
                Room = "Sala Benalmádena 002",
                Time = "13:00",
                Tags = ["Rendimiento", "Performance", "Medición"],
                MaxAttendees = 100
            },
            new Session
            {
                Title = "Aplicaciones agénticas con Gemma en Flutter",
                Description = "Acércate a conocer la siguiente evolución en la UX de tus aplicaciones gracias a los agentes de IA. Exploraremos la nueva generación de experiencias de usuario a través de las apps agénticas.",
                SpeakerName = "Alfredo Bautista Santos",
                SpeakerBio = "",
                Room = "Sala Canillas 013",
                Time = "13:00",
                Tags = ["Flutter", "Gemma", "IA", "Agentes"],
                MaxAttendees = 80
            },
            new Session
            {
                Title = "Cierre de OpenSouthCode 2026 / Closing OpenSouthCode 2026",
                Description = "Cierre de OpenSouthCode 2026 / Closing OpenSouthCode 2026",
                SpeakerName = "",
                SpeakerBio = "",
                Room = "Sala Fuengirola",
                Time = "13:45",
                Tags = ["Closing", "OpenSouthCode"],
                MaxAttendees = 300
            }
        );
        db.SaveChanges();
    }
}
