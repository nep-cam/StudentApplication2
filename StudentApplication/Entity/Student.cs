﻿namespace StudentApplication.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string StudentCode {  get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
