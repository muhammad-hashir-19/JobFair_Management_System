# 🎓 CareerConnect – Job Fair Management System

CareerConnect is a comprehensive, database-driven desktop application designed to streamline the management of job fairs at FAST-NUCES Islamabad. Built using **C# Windows Forms** and **SQL Server**, the system provides tailored interfaces and workflows for students, recruiters, TPO (Training & Placement Office), and booth coordinators to manage the full lifecycle of job fair events.


## 👥 Collaborators

- 🧑‍💻 Muhammad Hashir (23I-3047)  
- 🧑‍💻 Zaki Haider (23I-3091)


## 🔁 Project Iterations

### 🔹 Iteration 1: Database Design

**Tools Used:** SQL Server Management Studio  

**Deliverables:**
- Entity Relationship Diagram (ERD)
- Normalized relational schema (up to 3NF)
- Data insertion scripts

**Key Tables:**
- USERS, STUDENT, RECRUITER, TPO, COORDINATOR  
- JOB_FAIR_EVENTS, BOOTH, COMPANY  
- INTERVIEWS, APPLICATION  
- Associative tables for skills, reviews, job postings, etc.

**Sample Data Requirements:**
- 80+ students  
- 20+ companies  
- 5+ job fairs  
- 200+ applications and interviews  


### 🔹 Iteration 2: Interface Design

**Platform:** Windows Forms (Visual Studio 2019+)

**Key Interfaces:**
- Student: Login, profile creation, job browsing, interview scheduling  
- Recruiter: Job posting, applicant filtering, interview management  
- TPO: Admin dashboard, approvals, event scheduling, reporting  
- Booth Coordinator: Check-ins, booth traffic tracking  

**Navigation Flow:**
- Role-based modular access after login  
- Seamless form transitions with context passing (e.g., studentID)


### 🔹 Iteration 3: Final Integration & Functionality

**Backend:** SQL Server (Stored Procedures)  
**Frontend:** Windows Forms (C#)

**Core Features:**
- Secure authentication (students via FAST email, recruiters via approval)  
- Profile management (GPA, semester, certifications, skills)  
- Advanced job search (salary, type, skills, location filters)  
- Interview scheduling with time slots and reviews  
- Event & booth management with real-time tracking  
- Admin analytics and reporting tools  


## 🧩 Key Functional Modules

### 👨‍🎓 Student Interface
- Register/login via FAST email  
- Build academic & skill profile  
- Search & apply for jobs  
- Schedule interviews and submit feedback  

### 🏢 Recruiter Interface
- Submit company and job postings  
- View/filter applications  
- Schedule interviews and finalize hiring decisions  

### 🧑‍💼 TPO (Admin) Interface
- Approve/reject users  
- Manage job fair events  
- Assign booths and coordinators  
- Generate system reports  

### 🧑‍🔧 Booth Coordinator Interface
- Manage booth check-ins  
- Track visitor flow and activity  


## 🛠️ Tech Stack

- **Frontend:** C# Windows Forms  
- **Backend:** SQL Server  
- **Development Tool:** Visual Studio 2019  
- **Data Access:** ADO.NET / Stored Procedures  
- **Database Design:** Normalized up to 3NF  

## 📊 Reports & Analytics

- **Student Participation:** GPA distribution, department stats  
- **Recruiter Activity:** Interview counts, hiring trends  
- **Placement Summary:** Hiring %, average salaries  
- **Event Performance:** Booth traffic, peak hours  

---

## 📌 Notes

- Role-based access control implemented  
- Strong data validation (UI + database level)  
- Fully functional CRUD operations for all roles  

🎥 A demo video is included showing:
- Login & navigation  
- System workflows  
- Report generation  


## 🔐 Plagiarism Policy

This project strictly adheres to academic integrity policies. All work is original and developed from scratch by the collaborators.


## 📄 Documentation Includes

- 📈 ER Diagram & Relational Schema  
- 🧠 Design Decisions  
- 📸 User Manual (Screenshots)  
- 🎥 System Demo Video  


## 💼 Authors

Made with 💻 and dedication by:

**Muhammad Hashir & Zaki Haider**  
FAST-NUCES SE-B  
DB Lab Final Project – Spring 2025
